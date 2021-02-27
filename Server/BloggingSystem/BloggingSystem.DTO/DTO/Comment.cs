using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.DTO
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Describtion { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; }
        public  Post Post { get; set; }
    }
}
