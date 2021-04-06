using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Data.Model
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

    }
}
