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
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryID { get; set; }
    }
}
