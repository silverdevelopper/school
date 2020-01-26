using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using school.Models;
namespace school.Data
{
    public class SchoolDbContext:DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options):
            base(options)
        {

        }
        public DbSet <Classe> Classes { get; set; }
        public DbSet <Student> Students { get; set; }
    }
}
