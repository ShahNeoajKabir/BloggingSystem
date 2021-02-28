using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.View_Model
{
    public class VMChangePassword
    {
        public int VMUserId { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string RetypePassword { get; set; }
    }
}
