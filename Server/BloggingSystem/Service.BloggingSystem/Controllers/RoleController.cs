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
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleBLLManager _roleBLLManager;
        public RoleController(IRoleBLLManager roleBLLManager)
        {
            _roleBLLManager = roleBLLManager;
        }


        [HttpPost]
        [Route("AddRole")]

        public async Task<ActionResult>AddRole([FromBody] Role role)
        {
            try
            {
               return Ok( await _roleBLLManager.AddRole(role));
            }
            catch (Exception ex )
            {

                throw new Exception("Can not Added");
            }
        }


        [HttpDelete]
        [Route("DeleteRole")]
        public async Task<ActionResult> DeleteRole(Role role)
        {
            try
            {
                var res = await _roleBLLManager.DeleteRole(role);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw new Exception("Can not deleted");
            }
        }
    }
}
