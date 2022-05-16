using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab6
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureDeleted(); //удаление существующей бд в файле
            Database.EnsureCreated(); //создание бд
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db"); // подключение к бд
        }
    }
}
    