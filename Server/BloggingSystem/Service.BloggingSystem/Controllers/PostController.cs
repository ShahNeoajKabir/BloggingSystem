﻿using System;
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
    [Route("api/Post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostBLLManager _postBLLManager;
        private readonly ICommentBLLManager _comment;
        public PostController(IPostBLLManager postBLLManager , ICommentBLLManager comment)
        {
            _postBLLManager = postBLLManager;
            _comment = comment;
        }

        [HttpPost]
        [Route("AddPost")]
        public async Task<ActionResult>AddPost([FromBody]TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Post post = JsonConvert.DeserializeObject<Post>(message.Content.ToString());
                post.CreatedBy = loggeduser.UserName;
                post.UserId = loggeduser.UserId;
                return Ok(await _postBLLManager.AddPost(post));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        [HttpGet]
        [Route("GetAll")]
        public List<Post> GetAll()
        {
            return _postBLLManager.GetAll();
        }


        [HttpGet]
        [Route("GetAllSports")]
        public List<Post> GetAllSports()
        {
            return _postBLLManager.GetAllSports();
        }


        [HttpPost]
        [Route("UpdatePost")]
        public async Task<ActionResult> UpdatePost([FromBody] TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Post post = JsonConvert.DeserializeObject<Post>(message.Content.ToString());
                post.UpdatedBy = loggeduser.UserName;
                post.UserId = loggeduser.UserId;
                return Ok(await _postBLLManager.UpdatePost(post));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }


        [HttpPost]
        [Route("DeletePost")]
        public async Task<ActionResult> DeletePost([FromBody] TempMessage message)
        {
            try
            {
                var loggeduser = (User)HttpContext.Items["User"];
                Post post = JsonConvert.DeserializeObject<Post>(message.Content.ToString());
                return Ok(await _postBLLManager.DeletePost(post));
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
                Post post = JsonConvert.DeserializeObject<Post>(message.Content.ToString());
                return Ok(await _postBLLManager.GetById(post));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        [HttpPost]
        [Route("ViewById")]
        public async Task<ActionResult> ViewById([FromBody] Post post)
        {
            try
            {
                return Ok(await _postBLLManager.ViewById(post));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }



        [HttpPost]
        [Route("AddComment")]
        public async Task<ActionResult> AddComment([FromBody] Comment comment)
        {
            try
            {
                return Ok(await _comment.AddComment(comment));
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        [HttpGet]
        [Route("GetComment")]
        public List<Comment>GetComment()
        {
            try
            {

                return  _comment.ViewComment();
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }
    }
}
