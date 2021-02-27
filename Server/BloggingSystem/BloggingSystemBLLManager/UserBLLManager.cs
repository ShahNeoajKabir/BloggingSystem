using BloggingSystem.DTO.DTO;
using BloggingSystemDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonBlogging;

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
                var check = _bloggingSystemDb.User.Where(p => p.Email == user.Email && p.MobileNo == user.MobileNo).FirstOrDefaultAsync();

                if(user.UserName!=null && user.Email!=null && user.Password !=null && user.MobileNo !=null && user.Age >0 && user.Image != null)
                {
                    if (check != null)
                    {
                        throw new Exception("Email is already exists");
                    }
                    else
                    {
                        user.CreatedDate = DateTime.Now;
                        user.CreatedBy = "Bappy";
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

        public async Task<bool> DeleteUser(User user)
        {
            
            try
            {
                var removeuser = _bloggingSystemDb.User.Where(p => p.UserId == user.UserId).AsNoTracking().FirstOrDefaultAsync();
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

        public async Task<List<User>> GetAll()
        {
            List<User> user =await _bloggingSystemDb.User.Where(p => p.Status == (int)CommonBlogging.Enum.Enum.Status.Active).ToListAsync();
            return user;
        }

        public async Task<User> GetById(int id)
        {
            var res = await _bloggingSystemDb.User.Where(p => p.UserId == id).FirstOrDefaultAsync();
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
                        var res = _bloggingSystemDb.SaveChanges();
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
    }




    public interface IUserBLLManager
    {
        Task<bool> AddUser(User user);
        Task<List<User>> GetAll();
        Task<bool> UpdateUser(User user);
        Task<User> GetById(int id);
        Task<bool> DeleteUser(User user);
    }
}
