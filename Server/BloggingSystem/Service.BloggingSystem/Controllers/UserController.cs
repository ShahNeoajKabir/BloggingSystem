using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingSystem.DTO.DTO;
using BloggingSystemBLLManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.BloggingSystem.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBLLManager _userBLLManager;
        public UserController(IUserBLLManager userBLLManager)
        {
            _userBLLManager = userBLLManager;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult>AddUser([FromBody] User user)
        {
            try
            {

                return Ok(await _userBLLManager.AddUser(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Please Try Again");
            }
        }

        [HttpGet]
        [Route("GetAllStuff")]

        public List<User> GetAllStuff()
        {
            return  _userBLLManager.GetAllStuff();
        }


        [HttpGet]
        [Route("GetAllUser")]

        public List<User> GetAllUser()
        {
            return _userBLLManager.GetAllUser();
        }

        [HttpGet]
        [Route("GetAllUnAssignUser")]

        public List<User> GetAllUnAssignUser()
        {
            return _userBLLManager.GetAllUnAssignUser();
        }


        [HttpPost]
        [Route("UpdateUser")]

        public async Task<ActionResult> UpdateUser([FromBody] User user)
        {
            try
            {
                return Ok(await _userBLLManager.UpdateUser(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }


        [HttpPost]
        [Route("GetById")]

        public async Task<ActionResult> GetById([FromBody] User user)
        {
            try
            {
                return Ok(await _userBLLManager.GetById(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }

        [HttpPost]
        [Route("GetByID")]

        public async Task<ActionResult> GetByID([FromBody] int user)
        {
            try
            {
                return Ok(await _userBLLManager.GetByID(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }


        [HttpPost]
        [Route("DeleteUser")]

        public async Task<ActionResult> DeleteUser([FromBody] User user)
        {
            try
            {
                return Ok(await _userBLLManager.DeleteUser(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }
    }
}
