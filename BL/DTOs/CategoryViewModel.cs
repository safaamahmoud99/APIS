using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
   public class CategoryViewModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public int MainCategoryID { get; set; }
        public string MainCategoryName { get; set; }
    }
}
