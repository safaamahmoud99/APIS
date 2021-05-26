using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Images")]
    public class Images
    {
        public int ID { get; set; }
        public string Image { get; set; }
    }
}
