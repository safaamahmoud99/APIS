using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class CartViewModel
    {
        public string UserID { get; set; }
        public double TotalPrice {get; set;}
       
    }
}
