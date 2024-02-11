
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolApplication.Context
{
    public class SchoolAppDbContext:DbContext
    {
        public SchoolAppDbContext()
        {
                
        }

        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options) : base(options)
        {


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            


           // optionsBuilder.UseSqlServer(@"Server=.; Database=SchoolDb2;Trusted_Connection=true; TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohammad\Desktop\SchoolManagement\data\SchoolDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                  base.OnModelCreating(modelBuilder);
        }
    }
    
}
