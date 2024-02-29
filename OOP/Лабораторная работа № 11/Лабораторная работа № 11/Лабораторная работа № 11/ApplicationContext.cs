using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Лабораторная_работа___11
{
    public class ApplicationContext : DbContext
    {
        public DbSet<SHOP> Shop => Set<SHOP>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DataBaseLaba8;Integrated Security=True");
        }
    }
}