using EmployeeInfo.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EmployeeInfo.Common.Helper
{
    public static class GenericMultiSorterPager
    {
        public static IList<T> GetSortedPagedList<T>(IQueryable<T> source, PaginationRequestBySortList paging, out int totalCount, ChildLoad childLoad = ChildLoad.None)
        {
            totalCount = 0;
            //If not need paging, pass the null PaginationRequest
            if (paging == null)
            {
                var list = source.ToList();
                totalCount = list.Count();
                return list;
            }
            source = source.Distinct();

            //Call to build sorted paged query
            IQueryable<T> sortedPagedQuery = GetSortedPagedQuerable<T>(source, paging);
            
            //Call db one time to get data rows and count together
            if (childLoad == ChildLoad.None)
            {
                //Build one-call query from created regular query
                var pagedGroup = from sel in sortedPagedQuery
                                 select new PagedResultSet<T>()
                                 {
                                     PagedData = sel,
                                     TotalCount = source.Count()
                                 };
                //Get the complete resultset from db.
                List<PagedResultSet<T>> pagedResultSet;
                try
                {
                    pagedResultSet = pagedGroup.AsParallel().ToList();
                }
                catch (NotSupportedException)
                {
                    //In case not supported with EF version, do two calls instead
                    totalCount = source.Count();
                    return sortedPagedQuery.ToList();
                }

                //Get data and total count from the resultset 
                IEnumerable<T> pagedList = new List<T>();
                if (pagedResultSet.Count() > 0)
                {
                    totalCount = pagedResultSet.First().TotalCount;
                    pagedList = pagedResultSet.Select(s => s.PagedData);
                }
                //Remove the wrapper reference 
                pagedResultSet = null;

                return pagedList.ToList();
            }
            //Call db twice when childLoad == Include or else
            else
            {
                totalCount = source.Count();
                return sortedPagedQuery.ToList();
            }
        }

        private static IQueryable<T> GetSortedPagedQuerable<T>(IQueryable<T> source, PaginationRequestBySortList paging)
        {
            IQueryable<T> pagedQuery = source;

            var tempPagedQuery = AsSortedQueryable<T>(source, paging.SortList);
            if (tempPagedQuery != null)
            {
                pagedQuery = tempPagedQuery;
            }
            
            //Construct paged query
            if (paging.PageSize > 0)
            {
                pagedQuery = AsPagedQueryable<T>(pagedQuery, paging.PageIndex, paging.PageSize);
            }
            else
            {
                //Passing PageSize 0 to get all rows but using sorting.
                paging.PageIndex = 0;
            }
            //Return sorted paged query
            return pagedQuery;
        }

        public static IOrderedQueryable<T> AsSortedQueryable<T>(this IQueryable<T> source, List<SortItem> sortList)
        {
            if (sortList.Count == 0)
            {
                return null;
            }               

            var param = Expression.Parameter(typeof(T), string.Empty);
            var property = Expression.PropertyOrField(param, sortList[0].SortBy);

            var sort = Expression.Lambda(property, param);

            MethodCallExpression orderByCall = Expression.Call(
                typeof(Queryable),
                "OrderBy" + (sortList[0].SortDirection == "desc" ? "Descending" : string.Empty),
                new[] { typeof(T), property.Type },
                source.Expression,
                Expression.Quote(sort));

            if (sortList.Count > 1)
            {
                for (int idx = 1; idx < sortList.Count; idx++)
                {
                    var item = sortList[idx].SortBy;
                    param = Expression.Parameter(typeof(T), string.Empty);
                    property = Expression.PropertyOrField(param, item);

                    sort = Expression.Lambda(property, param);

                    orderByCall = Expression.Call(
                        typeof(Queryable),
                        "ThenBy" + (sortList[idx].SortDirection == "desc" ? "Descending" : string.Empty),
                        new[] { typeof(T), property.Type },
                        orderByCall,
                        Expression.Quote(sort));
                }
            }
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(orderByCall);
        }

        public static IQueryable<T> AsPagedQueryable<T>(IQueryable<T> source, int pageIndex, int pageSize)
        {
            return source.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}