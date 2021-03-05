using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.DTO
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
