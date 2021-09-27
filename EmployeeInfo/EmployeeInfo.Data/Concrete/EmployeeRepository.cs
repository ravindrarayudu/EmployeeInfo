using EmployeeInfo.Common.Helper;
using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.Contracts.Entities.Custom;
using EmployeeInfo.Contracts.Entities.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = EmployeeInfo.Data.DataContext;

namespace EmployeeInfo.Data.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EF.EmployeeInfoContext _db;
        public EmployeeRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<Employee> GetEmployeeByIdAsync(int Id)
        {
            try
            {
                var employee = await _db.Employee.SingleOrDefaultAsync(a => a.Id == Id);

                return new Employee()
                {
                    Id  = employee.Id,
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    Gender = employee.Gender == "Male" ? Gender.Male : Gender.Female,
                    AddressId = employee.AddressId,
                    MaritalStatus = employee.MaritalStatus == "Married" ? MaritalStatus.Married : MaritalStatus.Single,
                    DateOfBirth = employee.DateOfBirth,
                    DateOfJoining = employee.DateOfJoining,
                    BloodGroup = employee.BloodGroup,
                    DesignationId = employee.DesignationId,
                    DepartmentId = employee.DepartmentId,
                    Mobile = employee.Mobile,
                    Aadhar = employee.Aadhar,
                    LocationId = employee.LocationId,
                    Uan = employee.Uan,
                    Esi = employee.Esi,
                    BankId = employee.BankId,
                    BankAccountNumber = employee.BankAccountNumber,
                    ModifiedDate  = employee.ModifiedDate,
                    ModifiedBy = employee.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<Employee> GetEmployeeByEmployeeIdAsync(string employeeId)
        {
            try
            {
                var employee = await _db.Employee.SingleOrDefaultAsync(a => a.EmployeeId == employeeId);

                return new Employee()
                {
                    Id = employee.Id,
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    Gender = employee.Gender == "Male" ? Gender.Male : Gender.Female,
                    AddressId = employee.AddressId,
                    MaritalStatus = employee.MaritalStatus == "Married" ? MaritalStatus.Married : MaritalStatus.Single,
                    DateOfBirth = employee.DateOfBirth,
                    DateOfJoining = employee.DateOfJoining,
                    BloodGroup = employee.BloodGroup,
                    DesignationId = employee.DesignationId,
                    DepartmentId = employee.DepartmentId,
                    Mobile = employee.Mobile,
                    Aadhar = employee.Aadhar,
                    LocationId = employee.LocationId,
                    Uan = employee.Uan,
                    Esi = employee.Esi,
                    BankId = employee.BankId,
                    BankAccountNumber = employee.BankAccountNumber,
                    ModifiedDate = employee.ModifiedDate,
                    ModifiedBy = employee.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _db.Employee.Select(employee => new Employee()
                {
                    Id = employee.Id,
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    Gender = employee.Gender == "Male" ? Gender.Male : Gender.Female,
                    AddressId = employee.AddressId,
                    MaritalStatus = employee.MaritalStatus == "Married" ? MaritalStatus.Married : MaritalStatus.Single,
                    DateOfBirth = employee.DateOfBirth,
                    DateOfJoining = employee.DateOfJoining,
                    BloodGroup = employee.BloodGroup,
                    DesignationId = employee.DesignationId,
                    DepartmentId = employee.DepartmentId,
                    Mobile = employee.Mobile,
                    Aadhar = employee.Aadhar,
                    LocationId = employee.LocationId,
                    Uan = employee.Uan,
                    Esi = employee.Esi,
                    BankId = employee.BankId,
                    BankAccountNumber = employee.BankAccountNumber,
                    ModifiedDate = employee.ModifiedDate,
                    ModifiedBy = employee.ModifiedBy

                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<EmployeeSearchResult> GetEmployeesAsync(EmployeeSearchRequest employeeSearchRequest)
        {
            try
            {
                var query = (from employee in _db.Employee
                             select new EmployeeSearch
                             {
                                 EmployeeName = employee.EmployeeName,
                                 Mobile = employee.Mobile,
                                 Aadhar = employee.Aadhar,
                                 Uan = employee.Uan,
                                 DateOfJoining = employee.DateOfJoining
                             });

                var predicate = PredicateBuilder.True<EmployeeSearch>();

                if (!string.IsNullOrEmpty(employeeSearchRequest.EmployeeName))
                {
                    predicate = predicate.And(p => p.EmployeeName == employeeSearchRequest.EmployeeName);
                }
                if (employeeSearchRequest.DateFrom != null && employeeSearchRequest.DateFrom != DateTime.MinValue)
                {
                    predicate = predicate.And(p => p.DateOfJoining >= employeeSearchRequest.DateFrom.Value);
                }
                if (employeeSearchRequest.DateTo != null && employeeSearchRequest.DateTo != DateTime.MinValue)
                {
                    predicate = predicate.And(p => p.DateOfJoining <= employeeSearchRequest.DateTo.Value);
                }
                if (employeeSearchRequest.Mobile != null && employeeSearchRequest.Mobile != "")
                {
                    predicate = predicate.And(p => p.Mobile == employeeSearchRequest.Mobile);
                }
                if (employeeSearchRequest.Aadhar != null && employeeSearchRequest.Aadhar != "")
                {
                    predicate = predicate.And(p => p.Aadhar == employeeSearchRequest.Aadhar);
                }
                if (employeeSearchRequest.Uan != null && employeeSearchRequest.Uan != "")
                {
                    predicate = predicate.And(p => p.Uan == employeeSearchRequest.Uan);
                }
                query = query.Where(predicate);

                int totalCount = employeeSearchRequest.TotalCount;

                IEnumerable<EmployeeSearch> employeeSearchList = GenericSorterPager.GetSortedPagedList<EmployeeSearch>(query, employeeSearchRequest.PaginationRequest, out totalCount);

                //For issue when refreshing data after CRUD causes no row in the current page.

                int newPageIndex = -1;

                if (employeeSearchRequest.PaginationRequest != null)
                {
                    while (employeeSearchRequest.PaginationRequest.PageIndex > 0 && employeeSearchList.Count() < 1)
                    {
                        employeeSearchRequest.PaginationRequest.PageIndex -= 1;
                        newPageIndex = employeeSearchRequest.PaginationRequest.PageIndex;
                        employeeSearchList = GenericSorterPager.GetSortedPagedList<EmployeeSearch>(query, employeeSearchRequest.PaginationRequest, out totalCount);
                    }
                }

                EmployeeSearchResult employeeSearchResult = new EmployeeSearchResult();
                employeeSearchResult.EmployeeSearchList = employeeSearchList;
                employeeSearchResult.NewPageIndex = newPageIndex;
                employeeSearchResult.TotalCount = totalCount;

                return await Task.FromResult<EmployeeSearchResult>(employeeSearchResult);
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }            
        public async Task<EmployeeSearchResult> GetEmployeesAsync(string employeeName,string mobile,string aadhar,string uan, DateTime? dateFrom,DateTime? dateTo,PaginationRequest paging, int totalCount,int newPageIndex)
        {
            IEnumerable<EmployeeSearch> employeeSearchList = GetEmployees(employeeName, mobile, aadhar, uan, dateFrom, dateTo, paging,out totalCount, out newPageIndex);
            EmployeeSearchResult employeeSearchResult = new EmployeeSearchResult();
            employeeSearchResult.EmployeeSearchList = employeeSearchList;
            employeeSearchResult.NewPageIndex = newPageIndex;
            employeeSearchResult.TotalCount = totalCount;
            return await Task.FromResult<EmployeeSearchResult>(employeeSearchResult);
        }
        public IEnumerable<EmployeeSearch> GetEmployees(string employeeName,string mobile,string aadhar,string uan,DateTime? dateFrom,DateTime? dateTo,PaginationRequest paging,out int totalCount,out int newPageIndex)
        {
            try
            {
                var query = (from employee in _db.Employee
                             select new EmployeeSearch
                             {
                                 EmployeeName = employee.EmployeeName,
                                 Mobile = employee.Mobile,
                                 Aadhar = employee.Aadhar,
                                 Uan    = employee.Uan,
                                 DateOfJoining = employee.DateOfJoining
                             });

                var predicate = PredicateBuilder.True<EmployeeSearch>();

                if (!string.IsNullOrEmpty(employeeName))
                {
                    predicate = predicate.And(p => p.EmployeeName == employeeName);
                }
                if (dateFrom != null && dateFrom != DateTime.MinValue)
                {
                    predicate = predicate.And(p => p.DateOfJoining >= dateFrom.Value);
                }
                if (dateTo != null && dateTo != DateTime.MinValue)
                {
                    predicate = predicate.And(p => p.DateOfJoining <= dateTo.Value);
                }
                if (mobile != null && mobile != "")
                {
                    predicate = predicate.And(p => p.Mobile == mobile);
                }
                if (aadhar != null && aadhar != "")
                {
                    predicate = predicate.And(p => p.Aadhar == aadhar);
                }
                if (uan != null && uan != "")
                {
                    predicate = predicate.And(p => p.Uan == uan);
                }
                query = query.Where(predicate);

                IEnumerable<EmployeeSearch> employeeSearchList = GenericSorterPager.GetSortedPagedList<EmployeeSearch>(query, paging, out totalCount);

                //For issue when refreshing data after CRUD causes no row in the current page.

                newPageIndex = -1;

                if (paging != null)
                {
                    while (paging.PageIndex > 0 && employeeSearchList.Count() < 1)
                    {
                        paging.PageIndex -= 1;
                        newPageIndex = paging.PageIndex;
                        employeeSearchList = GenericSorterPager.GetSortedPagedList<EmployeeSearch>(query, paging, out totalCount);
                    }
                }
                return employeeSearchList;
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditEmployeeAsync(Employee employee)
        {
            try
            {
                var employeeitem = new Employee()
                {
                    Id = employee.Id,
                    EmployeeId = employee.EmployeeId,
                    EmployeeName = employee.EmployeeName,
                    Gender = employee.Gender,
                    AddressId = employee.AddressId,
                    MaritalStatus = employee.MaritalStatus,
                    DateOfBirth = employee.DateOfBirth,
                    DateOfJoining = employee.DateOfJoining,
                    BloodGroup = employee.BloodGroup,
                    DesignationId = employee.DesignationId,
                    DepartmentId  = employee.DepartmentId,
                    Mobile        = employee.Mobile,
                    Aadhar = employee.Aadhar,
                    LocationId = employee.LocationId,
                    Uan = employee.Uan,
                    Esi = employee.Esi,
                    BankId = employee.BankId,
                    BankAccountNumber = employee.BankAccountNumber,
                    ModifiedDate = employee.ModifiedDate,
                    ModifiedBy = employee.ModifiedBy
                };
                _db.Entry(employeeitem).State = employeeitem.Id == 0 ? EntityState.Added : EntityState.Modified;
                int x = await (_db.SaveChangesAsync());
                return x;
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
    }
}
