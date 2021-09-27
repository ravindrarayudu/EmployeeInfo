using EmployeeInfo.Contracts.Abstract;
using EmployeeInfo.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF = EmployeeInfo.Data.DataContext;

namespace EmployeeInfo.Data.Concrete
{
    public class UserRepository : IUserRepository
    {

        private EF.EmployeeInfoContext _db;
        public UserRepository(EF.EmployeeInfoContext context)
        {
            _db = context;
        }
        public async Task<User> GetUserByIdAsync(Guid UserId)
        {
            try
            {
                var user = await _db.User.SingleOrDefaultAsync(a => a.UserId == UserId);

                return new User()
                {
                    UserId = user.UserId,
                    Phone = user.Phone,
                    Fax = user.Fax,
                    ContactName = user.ContactName,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsForgotPassword = user.IsForgotPassword,
                    LocationId = user.LocationId,
                    CreatedBy = user.CreatedBy,
                    ModifiedDate = user.ModifiedDate,
                    ModifiedBy = user.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<User> GetUserByNameAsync(string UserName)
        {
            try
            {
                var user = await _db.User.SingleOrDefaultAsync(a => a.UserName == UserName);

                return new User()
                {
                    UserId = user.UserId,
                    Phone = user.Phone,
                    Fax = user.Fax,
                    ContactName = user.ContactName,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsForgotPassword = user.IsForgotPassword,
                    LocationId = user.LocationId,
                    CreatedBy = user.CreatedBy,
                    ModifiedDate = user.ModifiedDate,
                    ModifiedBy = user.ModifiedBy
                };
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                return await _db.User.Select(user => new User()
                {
                    UserId = user.UserId,
                    Phone = user.Phone,
                    Fax = user.Fax,
                    ContactName = user.ContactName,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsForgotPassword = user.IsForgotPassword,
                    LocationId = user.LocationId,
                    CreatedBy = user.CreatedBy,
                    ModifiedDate = user.ModifiedDate,
                    ModifiedBy = user.ModifiedBy

                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex; // todo refactor
            }
        }
        public async Task<int> AddEditUserAsync(User user)
        {
            try
            {
                var useritem = new EmployeeInfo.Contracts.Models.User()
                {
                    UserId = user.UserId,
                    Phone = user.Phone,
                    Fax = user.Fax,
                    ContactName = user.ContactName,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsForgotPassword = user.IsForgotPassword,
                    LocationId = user.LocationId,
                    CreatedBy = user.CreatedBy,
                    ModifiedDate = user.ModifiedDate,
                    ModifiedBy = user.ModifiedBy
                };
                _db.Entry(useritem).State = useritem.UserId!=null ? EntityState.Added : EntityState.Modified;
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
