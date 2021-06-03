﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class MainCategoryViewModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
