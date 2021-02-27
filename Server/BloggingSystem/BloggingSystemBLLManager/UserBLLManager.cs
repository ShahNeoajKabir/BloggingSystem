using BloggingSystem.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystemBLLManager
{
    public class UserBLLManager
    {
    }




    public interface IUserBLLManager
    {
        Task<bool> AddUser(User user);
        Task<List<User>> GetAll();
        Task<bool> UpdateUser(User user);
        Task<User> GetById(int Userid);
    }
}
