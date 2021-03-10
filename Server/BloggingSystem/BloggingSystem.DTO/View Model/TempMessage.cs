using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystem.DTO.View_Model
{
    public class TempMessage
    {
        public string UserId { get; set; }
        public long? SessionId { get; set; }
        public string Content { get; set; }
        public int? UserType { get; set; }
    }
}
