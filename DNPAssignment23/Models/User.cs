using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DNPAssignment23.Models
{
    public class User
    {
        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int SecurityLevel { get; set; }
    }
}
