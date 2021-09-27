using System;
using System.Collections.Generic;


namespace EmployeeInfo.Contracts.Entities
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }

    public class PaginationRequest
    {        
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Sort Sort { get; set; }
    }

    public class Sort
    {
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }  
    }

    public class PaginationRequestBySortList
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public List<SortItem> SortList { get; set; }
        public PaginationRequestBySortList()
        {
            this.SortList = new List<SortItem>();
        }
    }

    public class SortItem
    {
        public string SortBy { get; set; }
        public string SortDirection { get; set; } //"asc", "desc", "".
    }
}
