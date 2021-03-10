using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingSystem.DTO.DTO;
using BloggingSystem.DTO.View_Model;
using BloggingSystemBLLManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public async Task<ActionResult>AddUser([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                user.CreatedBy = loginedUser.UserName;

                return Ok(await _userBLLManager.AddUser(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Please Try Again");
            }
        }

        [HttpPost]
        [Route("GetAllStuff")]

        public async Task<ActionResult> GetAllStuff([FromBody]TempMessage message)
        {

            try
            {
                return Ok( await _userBLLManager.GetAllStuff());

            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        [HttpGet]
        [Route("GetAllUser")]

        public List<User> GetAllUser()
        {
            try
            {
                return _userBLLManager.GetAllUser();

            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        [HttpGet]
        [Route("GetAllUnAssignUser")]

        public List<User> GetAllUnAssignUser()
        {
            return _userBLLManager.GetAllUnAssignUser();
        }


        [HttpPost]
        [Route("UpdateUser")]

        public async Task<ActionResult> UpdateUser([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());
                user.UpdatedBy = loginedUser.UserName;

                return Ok(await _userBLLManager.UpdateUser(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }


        [HttpPost]
        [Route("SerchBy")]

        public async Task<ActionResult> SerchBy([FromBody] TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());

                return Ok(await _userBLLManager.SerchBy(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }

        [HttpPost]
        [Route("GetByID")]

        public async Task<ActionResult> GetByID([FromBody] TempMessage message)
        {
            try
            {
                var user = JsonConvert.DeserializeObject<int>(message.Content.ToString());

                return Ok(await _userBLLManager.GetByID(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }


        [HttpPost]
        [Route("DeleteUser")]

        public async Task<ActionResult> DeleteUser([FromBody] TempMessage message)
        {
            try
            {
                User user = JsonConvert.DeserializeObject<User>(message.Content.ToString());

                return Ok(await _userBLLManager.DeleteUser(user));
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry Please Try Again");
            }
        }
    }
}
