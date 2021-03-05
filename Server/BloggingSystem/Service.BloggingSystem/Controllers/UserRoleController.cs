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
        public async Task<ActionResult> AddUserRole([FromBody] UserRole userRole)
        {
            try
            {
                
                userRole.CreatedBy = "Bappy";
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
        public async Task<ActionResult> UpdateUserRole([FromBody] UserRole userRole)
        {
            try
            {
                
                userRole.UpdatedBy = "Bappy";
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
        public async Task<ActionResult> GetById([FromBody] UserRole userRole)
        {
            try
            {
                return Ok(await _bLLManager.GetById(userRole));
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        [Route("DeleteUserRole")]
        public async Task<ActionResult> DeleteUserRole([FromBody] UserRole userRole)
        {
            try
            {
                return Ok(await _bLLManager.DeleteUserRole(userRole));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
