using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace school.Models
{
    public class Student
    {
        public int id { get; set; }
        [StringLength(64)]
        [Required]
        public string name { get; set; }
        public Classe Classe { get; set; }
        public int ClasseID { get; set; }
    }
}
