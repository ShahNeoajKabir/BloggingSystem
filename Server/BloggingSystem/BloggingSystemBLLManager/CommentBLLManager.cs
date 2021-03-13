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
    public class CommentBLLManager : ICommentBLLManager
    {
        private readonly BloggingSystemDbContext _dbContext;
        public CommentBLLManager(BloggingSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddComment(Comment comment)
        {
            try
            {
                var id = await _dbContext.Post.Where(p => p.PostId == comment.PostId).AsNoTracking().FirstOrDefaultAsync();
                if(id!=null)
                {
                    comment.CreatedDate = DateTime.Now;
                    await _dbContext.Comment.AddAsync(comment);
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

                throw new Exception("");
            }
        }

        public List<Comment> ViewComment()
        {
            try
            {
                List<Comment> comment = _dbContext.Comment.Select(u => new Comment()
                {
                    PostId=u.PostId,
                    CreatedDate=u.CreatedDate,
                    Describtion=u.Describtion,
                    Post=u.Post,
                    UserName=u.UserName
                }).ToList();
                return comment;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }
    }


    public interface ICommentBLLManager
    {
        Task<bool> AddComment(Comment comment);
        List<Comment> ViewComment();
    }
}
