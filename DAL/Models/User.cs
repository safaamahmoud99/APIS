using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class User:IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare ("Password")]
        public string confirmPassword { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
