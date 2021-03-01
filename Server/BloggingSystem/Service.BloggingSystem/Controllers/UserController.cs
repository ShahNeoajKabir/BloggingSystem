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
    }
}
