using BloggingSystem.DTO.DTO;
using BloggingSystem.DTO.View_Model;
using BloggingSystemDatabase;
using CommonBlogging.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystemBLLManager
{
    public class SecurityBLLManager : ISecurityBLLManager
    {

        private readonly BloggingSystemDbContext _bloggingSystem;
        public SecurityBLLManager(BloggingSystemDbContext bloggingSystem)
        {
            _bloggingSystem = bloggingSystem;
        }
        public async Task<User> Login(VMLogin vMLogin)
        {
            try
            {
                User objuser = new User();
                vMLogin.Password = new Encryptionservice().Encrypt(vMLogin.Password);

                objuser = await _bloggingSystem.User.Where(p => p.Email == vMLogin.Email && p.Password == vMLogin.Password).AsNoTracking().Select(u => new User()
                {
                    UserName=u.UserName,
                    UserType=u.UserType,
                    Email=u.Email,
                    MobileNo=u.MobileNo,
                    Age=u.Age,
                    Image=u.Image,
                    CreatedBy=u.CreatedBy,
                    CreatedDate=u.CreatedDate,
                    UpdatedBy=u.UpdatedBy,
                    UpdatedDate=u.UpdatedDate,
                    UserId=u.UserId

                }).FirstOrDefaultAsync();

                var Role = _bloggingSystem.UserRole.Where(p => p.UserId == objuser.UserId && p.Status == 1).AsNoTracking().FirstOrDefault();
                if (Role != null)
                {
                    objuser.Role = Role.RoleId;
                }
                else
                {
                    throw new Exception("You are not assign to any role");
                }


                return objuser;

            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please try again");
            }
        }
    }


    public interface ISecurityBLLManager
    {
        Task<User> Login(VMLogin vMLogin);
    }
}
