﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school.Models
{
    public class Classe
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
    }
}