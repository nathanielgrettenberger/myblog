﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Adding using statement

namespace MyBlog.Models
{
    public class Register
    {
        [Required]
        public string Username { get; set; }

        [Required,
        DataType(DataType.Password)]
        public string Password { get; set; }
        [Required,
        DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required, MaxLength(50)]
            
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string ImageURl { get; set; }
    }
}