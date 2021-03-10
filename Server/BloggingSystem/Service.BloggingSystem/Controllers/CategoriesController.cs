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
    [Route("api/Categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesBLLManager _categoriesBLL;
        public CategoriesController(ICategoriesBLLManager categoriesBLL)
        {
            _categoriesBLL = categoriesBLL;
        }


        [HttpPost]
        [Route("AddCategories")]
        public async Task<ActionResult> AddCategories([FromBody] TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                categories.CreatedBy = loggeduser.UserName;
                return Ok(await _categoriesBLL.AddCategories(categories));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        [HttpPost]
        [Route("UpdateCategories")]
        public async Task<ActionResult> UpdateCategories([FromBody] TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                categories.UpdatedBy = loggeduser.UpdatedBy;
                return Ok(await _categoriesBLL.UpdateCategories(categories));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        [HttpPost]
        [Route("DeleteCategories")]
        public async Task<ActionResult> DeleteCategories([FromBody] TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                return Ok(await _categoriesBLL.DeleteCategories(categories));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        [HttpPost]
        [Route("GetById")]
        public async Task<ActionResult> GetById([FromBody] TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Categories categories = JsonConvert.DeserializeObject<Categories>(message.Content.ToString());
                return Ok(await _categoriesBLL.GetById(categories));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public List<Categories> GetAll()
        {
            try
            {
                var res =  _categoriesBLL.GetAll();
                return res;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }
    }
}
