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
    public class RoleBLLManager : IRoleBLLManager
    {
        private readonly BloggingSystemDbContext _roleDbContext;
        public RoleBLLManager(BloggingSystemDbContext roleDbContext)
        {
            _roleDbContext = roleDbContext;
        }
        public async Task<bool> AddRole(Role role)
        {
            try
            {
                var check = await _roleDbContext.Role.Where(p => p.RoleName == role.RoleName).FirstOrDefaultAsync(); 

                if(role.RoleName!=null && role.Status > 0)
                {
                    if (check != null)
                    {
                        throw new Exception("Something is wrong !!!");
                    }
                    else
                    {
                        
                        role.CreatedDate = DateTime.Now;
                        await _roleDbContext.Role.AddAsync(role);
                        var res = await _roleDbContext.SaveChangesAsync();

                        if (res > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                else
                {
                    throw new Exception("Try Again");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Please Try Agin");
            }
        }

        public async Task<bool> DeleteRole(Role role)
        {
            try
            {
                var checkid = await _roleDbContext.Role.Where(p => p.RoleId == role.RoleId).AsNoTracking().FirstOrDefaultAsync();

                if (checkid != null)
                {
                    _roleDbContext.Role.Remove(role);
                    var res = await _roleDbContext.SaveChangesAsync();

                    if (res > 0)
                    {
                        return true;
                    }

                    else
                    {
                        return false;
                    }
                }

                else
                {
                    throw new Exception("Id Cant Found Please try again!!");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Id Cant Found Please try again!!");
            }
        }

        public List<Role> GetAll()
        {
            List<Role> role = _roleDbContext.Role.ToList();
            return role;
        }

        public async Task<Role> GetById(Role role)
        {
            var roleid = await _roleDbContext.Role.Where(p => p.RoleId == role.RoleId).FirstOrDefaultAsync();
            return roleid;
        }

        public async Task<bool> UpdateRole(Role role)
        {
            try
            {
                var roleid = await _roleDbContext.Role.Where(p => p.RoleId == role.RoleId).AsNoTracking().FirstOrDefaultAsync();
                if (roleid != null)
                {
                    var check = await _roleDbContext.Role.Where(p => p.RoleName == role.RoleName).AsNoTracking().FirstOrDefaultAsync();

                    if (check != null)
                    {
                        throw new Exception("Something is wrong!!");
                    }

                    else
                    {
                        
                        role.UpdatedDate = DateTime.Now;
                        _roleDbContext.Role.Update(role);
                        var res = await _roleDbContext.SaveChangesAsync();
                        if (res > 0)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Try Again");
                        }
                    }

                }
                else
                {
                    throw new Exception("Try Again");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public interface IRoleBLLManager
    {
        Task<bool> AddRole(Role role);
        Task<bool> UpdateRole(Role role);
        Task<bool> DeleteRole(Role role);
        Task<Role> GetById(Role role);
        List<Role> GetAll();
    }
}
