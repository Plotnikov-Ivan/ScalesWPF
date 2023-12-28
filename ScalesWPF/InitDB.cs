using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ScalesWPF
{
    public class InitDB: DbContext
    {

        public DbSet<Cars> Cars { get; set; } = null!;

        public InitDB() // Создание базы данных, если она еще не существует.                             
        {                   
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>().HasKey(c => new { c.Num, c.ContainerDate});

            // Другие настройки сущностей

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                                                                               //Метод настраивает параметры подключения к базе данных, используя провайдер PostgreSQL.                                                                                       //В данном случае, параметры подключения указываются явно в строке подключения
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Cars;Username=postgres;Password=stud");
        }
    }
}
