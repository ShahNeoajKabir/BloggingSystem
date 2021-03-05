using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.DTO
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Describtion { get; set; }
        public string PostTag { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
        public DateTime? PostTime { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public  User User { get; set; }
        public  Categories Categories { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }

    }
}
