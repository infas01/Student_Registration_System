using Microsoft.EntityFrameworkCore;
using SRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRS
{
    public class DatabaseContext : DbContext
    {

        public string path = @"C:\Users\Infas_NM\Desktop\GUI_Project\GUI_Project\SRS\StudentDatabase.db";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source = {path}");

        }

        public DbSet<UserM> Users { get; set; }
        public DbSet<StudentM> Students { get; set; }
        public DbSet<Module> Modules { get; set; }

    }

}
