using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.DTO
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Describtion { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedDate { get; set; }
        public  Post Post { get; set; }
    }
}
