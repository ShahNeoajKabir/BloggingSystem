﻿using BloggingSystem.DTO.DTO;
using BloggingSystemDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBlogging;
using BloggingSystem.DTO.View_Model;
using CommonBlogging.Utility;

namespace BloggingSystemBLLManager
{
    public class UserBLLManager : IUserBLLManager
    {
        private readonly BloggingSystemDbContext _bloggingSystemDb;
        public UserBLLManager(BloggingSystemDbContext bloggingSystemDb)
        {
            _bloggingSystemDb = bloggingSystemDb;
        }
        public async Task<bool> AddUser(User user)
        {
            
            
            try
            {
                var check = await _bloggingSystemDb.User.Where(p => p.Email == user.Email).FirstOrDefaultAsync();

                if (user.UserName!=null && user.Email!=null && user.Password !=null && user.MobileNo !=null && user.Age >17 && user.Image != null)
                {
                    if (check != null)
                    {
                        throw new Exception("Email is already exists");
                    }
                    else
                    {
                        user.CreatedDate = DateTime.Now;
                        user.Password = new Encryptionservice().Encrypt(user.Password);
                        await _bloggingSystemDb.User.AddAsync(user);
                        var result = await _bloggingSystemDb.SaveChangesAsync();
                        if (result > 0)
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception("Something is Wrong");
                        }
                    }
                }
                else
                {
                    throw new Exception("Something is wrong please try again");
                }

                
            }
            catch (Exception ex)
            {

                throw new Exception("Try Again");
            }
        }
        public List<User> GetAllUnAssignUser()
        {
            List<User> user = new List<User>();
            var userrolelist = _bloggingSystemDb.UserRole.Where(p => p.Status == (int)CommonBlogging.Enum.Enum.Status.Active).Select(c => c.UserId).ToArray();
            if (userrolelist.Length > 0)
            {
                user = _bloggingSystemDb.User.Where(p => !userrolelist.Contains(p.UserId)).ToList();

            }
            else
            {
                user = _bloggingSystemDb.User.Where(p => p.Status == (int)CommonBlogging.Enum.Enum.Status.Active).ToList();

            }
            return user;
        }


        public async Task<bool> DeleteUser(User user)
        {
            
            try
            {
                var removeuser =await _bloggingSystemDb.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (removeuser != null)
                {
                    _bloggingSystemDb.User.Remove(user);
                    var result=await _bloggingSystemDb.SaveChangesAsync();
                    if (result > 0)
                    { 
                        return true;
                    }
                    else
                    {
                        throw new Exception("Please Try Again");
                    }

                }

                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Can not delete");
            }
        }

        public async Task<List<VmUsers>> GetAllStuff()
        {
            List<VmUsers> user = await _bloggingSystemDb.User.Where(p => p.Status == (int)CommonBlogging.Enum.Enum.UserType.Admin || p.UserType== (int)CommonBlogging.Enum.Enum.UserType.Moderator).Select(c => new VmUsers()
            {

                Email = c.Email,
                MobileNo = c.MobileNo,
                RoleName = c.UserRole.Where(p => p.Status == 1).FirstOrDefault().Role.RoleName,
                Status = c.Status,
                UserId = c.UserId,
                UserName = c.UserName,
                Image=c.Image,
                Age=c.Age,
                UserType=c.UserType
                

            }).ToListAsync();
            return user;
        }

        //public List<User> GetAllStuff()
        //{
        //    List<User> user = _bloggingSystemDb.User.Where(p => p.Status == (int)CommonBlogging.Enum.Enum.Status.Active).ToList();
        //    return user;
        //}

        public List<User> GetAllUser()
        {
            List<User> user = _bloggingSystemDb.User.Where(p => p.UserType == (int)CommonBlogging.Enum.Enum.UserType.User).ToList();
            return user;
        }


        public async Task<User> SerchBy(User user)
        {
            var res = await _bloggingSystemDb.User.Where(p => p.UserId == user.UserId).FirstOrDefaultAsync();
            return res;
        }

        public async Task<User> GetByID(int user)
        {
            var res = await _bloggingSystemDb.User.Where(p => p.UserId == user).FirstOrDefaultAsync();
            var roleid = await _bloggingSystemDb.UserRole.Where(p => p.UserId == user && p.Status == (int)CommonBlogging.Enum.Enum.Status.Active).FirstOrDefaultAsync();
            if (roleid != null)
            {
                res.Role = roleid.RoleId;
            }
            return res;
        }

        public async Task<bool> UpdateUser(User user)
        {

            try
            {
                var id = await _bloggingSystemDb.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (id != null)
                {
                    var checkemail = await _bloggingSystemDb.User.Where(p => p.Email == user.Email).AsNoTracking().FirstOrDefaultAsync();
                    if (checkemail != null)
                    {
                        throw new Exception("Please Try Again");
                    }
                    else
                    {
                        user.UpdatedBy = "Bappy";
                        user.UpdatedDate = DateTime.Now;
                        _bloggingSystemDb.User.Update(user);
                        var res = await _bloggingSystemDb.SaveChangesAsync();
                        if (res > 0)
                        {
                            return true;
                        }

                        else
                        {
                            throw new Exception("Bad Request");
                        }

                    }
                }

                else
                {
                    throw new Exception("Please Try Again");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<bool> ChangePassword(VMChangePassword vMChangePassword)
        {
            bool res = false;
            try
            {
                vMChangePassword.OldPassword = new Encryptionservice().Encrypt(vMChangePassword.OldPassword);
                vMChangePassword.NewPassword = new Encryptionservice().Encrypt(vMChangePassword.NewPassword);
                vMChangePassword.RetypePassword = new Encryptionservice().Encrypt(vMChangePassword.RetypePassword);

                var check = await _bloggingSystemDb.User.Where(p => p.UserId == vMChangePassword.VMUserId && p.Email == vMChangePassword.Email && p.Password == vMChangePassword.OldPassword).FirstOrDefaultAsync();
                if (check != null)
                {
                    if(vMChangePassword.NewPassword==vMChangePassword.RetypePassword && vMChangePassword.NewPassword != vMChangePassword.OldPassword)
                    {
                        check.Password = vMChangePassword.NewPassword;
                        check.UpdatedDate = DateTime.Now;
                        check.UpdatedBy = check.UserName;

                        _bloggingSystemDb.User.Update(check);
                        var count=_bloggingSystemDb.SaveChanges();
                        if (count > 0)
                        {
                            res = true;
                        }
                        
                    }
                    else
                    {
                        throw new Exception("Something Is Wrong");
                    }
                }

                return res;
            }
            catch (Exception ex)
            {

                throw new Exception("Something Is Wrong");
            }
        }
    }




    public interface IUserBLLManager
    {
        Task<bool> AddUser(User user);
        //List<User> GetAllStuff();
        List<User> GetAllUser();
        Task<List<VmUsers>> GetAllStuff();
        Task<bool> UpdateUser(User user);
        Task<User> SerchBy(User user);
        Task<User> GetByID(int user);
        Task<bool> DeleteUser(User user);
        Task<bool> ChangePassword(VMChangePassword vMChangePassword);
        List<User> GetAllUnAssignUser();
    }
}
