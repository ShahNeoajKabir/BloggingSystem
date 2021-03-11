using BloggingSystem.DTO.DTO;
using BloggingSystemDatabase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystemBLLManager
{
    public class PostBLLManager : IPostBLLManager
    {
        private readonly BloggingSystemDbContext _dbContext;
        public PostBLLManager(BloggingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddPost(Post post)
        {
            try
            {
                var user = await _dbContext.User.Where(p => p.UserId == post.UserId).FirstOrDefaultAsync();
                var categori = await _dbContext.Categories.Where(p => p.CategoriesId == post.CategoryId).FirstOrDefaultAsync();
                if (post.Describtion!=null && post.Image!=null && post.PostTag!=null  && user!=null)
                {
                    post.CreatedDate = DateTime.Now;
                    post.UpdatedDate = DateTime.Now;
                    post.PostTime = DateTime.Now;
                    post.CategoryId = categori.CategoriesId;
                    post.Status = (int)CommonBlogging.Enum.Enum.Status.Active;
                    await _dbContext.Post.AddAsync(post);
                    var res = await _dbContext.SaveChangesAsync();
                    if (res > 0)
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("");
                    }
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex) 
            {

                throw new Exception("Something is Wrong !! Try Again");
            }
        }

        public Task<bool> DeletePost(Post post)
        {
            throw new NotImplementedException();
        }

        public List<Post> GetAll()
        {
            try
            {
                List<Post> post = _dbContext.Post.Select(u => new Post()
                {
                    Categories=u.Categories,
                    CategoryId=u.CategoryId,
                    CreatedBy=u.CreatedBy,
                    CreatedDate=u.CreatedDate,
                    Describtion=u.Describtion,
                    Image=u.Image,
                    PostId=u.PostId,
                    PostTag=u.PostTag,
                    PostTime=u.PostTime,
                    Title=u.Title,
                    User=u.User,
                    UserId=u.UserId,
                    UpdatedBy=u.UpdatedBy,
                    UpdatedDate=u.UpdatedDate,
                    Status=u.Status,
                    Comment=u.Comment
                }).ToList();
                return post;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        public Task<Post> GetById(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }



    public interface IPostBLLManager
    {
        Task<bool> AddPost(Post post);
        Task<bool> UpdatePost(Post post);
        Task<bool> DeletePost(Post post);
        Task<Post> GetById(Post post);
        List<Post>GetAll();
    }
}
