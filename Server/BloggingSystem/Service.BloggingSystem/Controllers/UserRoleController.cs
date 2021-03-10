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
    [Route("api/UserRole")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleBLLManager _bLLManager;
        public UserRoleController(IUserRoleBLLManager bLLManager)
        {
            _bLLManager = bLLManager;
        }


        [HttpPost]
        [Route("AddUserRole")]
        public async Task<ActionResult> AddUserRole([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                userRole.CreatedBy = loginedUser.UserName;
                await _bLLManager.AddUserRole(userRole);
                return Ok(userRole);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public List<UserRole> GetAll()
        {
            return _bLLManager.GetAll();
        }


        [HttpPost]
        [Route("UpdateUserRole")]
        public async Task<ActionResult> UpdateUserRole([FromBody] TempMessage message)
        {
            try
            {

                var loginedUser = (User)HttpContext.Items["User"];
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                userRole.UpdatedBy = loginedUser.UserName;
                await _bLLManager.UpdateUserRole(userRole);
                return Ok(userRole);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());
                return Ok(await _bLLManager.GetById(userRole));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("DeleteUserRole")]
        public async Task<ActionResult> DeleteUserRole([FromBody] TempMessage message)
        {
            try
            {
                UserRole userRole = JsonConvert.DeserializeObject<UserRole>(message.Content.ToString());

                return Ok(await _bLLManager.DeleteUserRole(userRole));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
