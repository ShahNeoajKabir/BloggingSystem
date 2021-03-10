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

        public async Task<ActionResult>AddRole([FromBody] TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                role.CreatedBy = loginedUser.UserName;
                return Ok( await _roleBLLManager.AddRole(role));
            }
            catch (Exception ex )
            {

                throw new Exception("Can not Added");
            }
        }


        [HttpPost]
        [Route("DeleteRole")]
        public async Task<ActionResult> DeleteRole(TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                var res = await _roleBLLManager.DeleteRole(role);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw new Exception("Can not deleted");
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public List<Role> GetAll()
        {
            try
            {
                var res=_roleBLLManager.GetAll();
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception("Can not show");
            }
        }


        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById(TempMessage message)
        {
            try
            {
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                var res = await _roleBLLManager.GetById(role);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw new Exception("Can not show");
            }
        }

        [HttpPost]
        [Route("UpdateRole")]
        public async Task<ActionResult> UpdateRole(TempMessage message)
        {
            try
            {
                var loginedUser = (User)HttpContext.Items["User"];
                Role role = JsonConvert.DeserializeObject<Role>(message.Content.ToString());
                role.CreatedBy = loginedUser.UserName;
                var res = await _roleBLLManager.UpdateRole(role);
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw new Exception("Can not show");
            }
        }
    }
}
