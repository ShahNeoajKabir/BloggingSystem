using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.View_Model
{
    public class VMPost
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostTime { get; set; }
        public int CommentsCounter { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int USerID { get; set; }
        public string UserName { get; set; }
        //public Categories Category { get; set; } = new Categories();
        //public User Account { get; set; } = new User();
    }
}
