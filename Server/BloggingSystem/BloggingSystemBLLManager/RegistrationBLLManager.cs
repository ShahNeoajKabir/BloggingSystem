using BloggingSystem.DTO.DTO;
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
    public class RegistrationBLLManager : IRegistrationBLLManager
    {

        private readonly BloggingSystemDbContext _bloggingSystemDb;
        public RegistrationBLLManager(BloggingSystemDbContext bloggingSystemDb)
        {
            _bloggingSystemDb = bloggingSystemDb;
        }
        public async Task<bool> Registration(User user)
        {

            try
            {
                var check = _bloggingSystemDb.User.Where(p => p.Email == user.Email && p.MobileNo == user.MobileNo).FirstOrDefaultAsync();

                if (user.UserName != null && user.Email != null && user.Password != null && user.MobileNo != null && user.Age > 17 && user.Image != null)
                {
                    if (check != null)
                    {
                        throw new Exception("Email is already exists");
                    }
                    else
                    {
                        user.UserType = (int)CommonBlogging.Enum.Enum.UserType.User;
                        user.Status = (int)CommonBlogging.Enum.Enum.Status.Active;
                        user.Password = new Encryptionservice().Encrypt(user.Password);
                        user.CreatedDate = DateTime.Now;
                        user.CreatedBy = user.UserName;
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
    }


    public interface IRegistrationBLLManager
    {
        Task<bool> Registration(User user);
    }
}
