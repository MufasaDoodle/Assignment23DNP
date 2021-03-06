﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DNPAssignment23.Models
{
    public class User
    {
        //[Required]
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [JsonPropertyName("ID")]
        public int UserID { get; set; }
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
        [JsonPropertyName("SecurityLevel")]
        public int SecurityLevel { get; set; }
    }
}
