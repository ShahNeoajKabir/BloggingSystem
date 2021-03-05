using BloggingSystem.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BloggingSystemBLLManager
{
    public class PostBLLManager : IPostBLLManager
    {
        public async Task<bool> AddPost(Post post)
        {
            try
            {
                return true;
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
            throw new NotImplementedException();
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
