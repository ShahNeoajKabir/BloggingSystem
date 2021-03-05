using BloggingSystem.DTO.DTO;
using BloggingSystemDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystemBLLManager
{
    public class UserRoleBLLManager : IUserRoleBLLManager
    {

        private readonly BloggingSystemDbContext _dbContext;
        public UserRoleBLLManager(BloggingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserRole> AddUserRole(UserRole userRole)
        {
            try
            {
                var user = await _dbContext.User.Where(p => p.UserId == userRole.UserId).FirstOrDefaultAsync();
                if (user!=null && userRole.RoleId > 0 )
                {
                    userRole.CreatedDate = DateTime.Now;
                    await _dbContext.UserRole.AddAsync(userRole);
                    await _dbContext.SaveChangesAsync();
                    return userRole;
                }
                else
                {
                    throw new Exception("");

                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public List<UserRole> GetAll()
        {
            List<UserRole> userRole = _dbContext.UserRole.Where(p => p.Status == (int)CommonBlogging.Enum.Enum.Status.Active).Select(t => new UserRole()
            {
                CreatedBy = t.CreatedBy,
                CreatedDate = t.CreatedDate,
                Status = t.Status,
                User = t.User,
                Role = t.Role,
                UserId = t.UserId,
                RoleId = t.RoleId,
                UserRoleId = t.UserRoleId
            }).ToList();
            return userRole;
        }


        public async Task<UserRole> UpdateUserRole(UserRole userRole)
        {
            try
            {

                var res = await _dbContext.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null && userRole.UserId > 0)
                {

                    userRole.UpdatedDate = DateTime.Now;
                    _dbContext.UserRole.Update(userRole);
                    await _dbContext.SaveChangesAsync();
                }

                else
                {
                    throw new Exception("Try Again");
                }

                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<UserRole> GetById(UserRole userRole)
        {
            var res = await _dbContext.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).FirstOrDefaultAsync();
            return res;
        }

        public async Task<UserRole> DeleteUserRole(UserRole userRole)
        {
            try
            {
                var res = await _dbContext.UserRole.Where(p => p.UserRoleId == userRole.UserRoleId).AsNoTracking().FirstOrDefaultAsync();
                if (res != null )
                {
                    _dbContext.UserRole.Remove(userRole);
                    await _dbContext.SaveChangesAsync();
                }

                else
                {
                    throw new Exception("Try Again");
                }

                return userRole;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }



    public interface IUserRoleBLLManager
    {
        Task<UserRole> AddUserRole(UserRole userRole);
        List<UserRole> GetAll();
        Task<UserRole> UpdateUserRole(UserRole userRole);
        Task<UserRole> DeleteUserRole(UserRole userRole);
        Task<UserRole> GetById(UserRole userRole);
    }
}
