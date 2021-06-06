using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Category")]
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        [ForeignKey("mainCategory")]
        public int MainCategoryID { get; set; }
        public MainCategory mainCategory { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
