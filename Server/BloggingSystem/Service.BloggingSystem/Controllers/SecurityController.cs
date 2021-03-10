using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingSystem.DTO.View_Model;
using BloggingSystemBLLManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.BloggingSystem.Handler;

namespace Service.BloggingSystem.Controllers
{
    [Produces("application/json")]
    [Route("api/Security")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityBLLManager _securityBLL;
        private readonly IAuthenticationManager _authenticationManager;
        public SecurityController(ISecurityBLLManager securityBLL, IAuthenticationManager authenticationManager)
        {
            _securityBLL = securityBLL;
            _authenticationManager = authenticationManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] TempMessage message)
        {
            VMLogin userLogin = JsonConvert.DeserializeObject<VMLogin>(message.Content);
            var result = await _securityBLL.Login(userLogin);
            if (result != null)
            {
                var token = _authenticationManager.BuildToken(result);
                return Ok(token);
                //return  ok(new { Token = this.authenticationManager.BuildToken(Converter.ObjectConvert<User>(result)) });
            }
            else
            {
                return NotFound("User not Authenticate");
            }


        }
    }
}
