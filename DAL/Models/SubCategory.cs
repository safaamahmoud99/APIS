using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class SubCategory
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
