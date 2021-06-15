﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class RegisterationViewModel
    {
    
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string confirmPassword { get; set; }
        public string Role { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
