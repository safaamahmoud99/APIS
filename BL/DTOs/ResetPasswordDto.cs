using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class ResetPasswordDto
    {
        [DataType(DataType.Password), Required(ErrorMessage = "Old Password Required")]
        public string currentPassword { get; set; }

        [DataType(DataType.Password), Required(ErrorMessage = "New Password Required")]
        public string newPassword { get; set; }
    }
}
