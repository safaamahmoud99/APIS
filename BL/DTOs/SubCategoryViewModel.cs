using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class SubCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
