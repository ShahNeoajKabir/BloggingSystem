using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.View_Model
{
    public class VMComment
    {
        public int USerID { get; set; }
        public string UserName { get; set; }
        public int PostID { get; set; }
        public string Description { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
