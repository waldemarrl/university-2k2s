using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class ApplicationContext : DbContext
    {
        public DbSet<AUTHORS> Authors => Set<AUTHORS>();
        public DbSet<BOOKS> Books => Set<BOOKS>();
        public DbSet<EDITION> Edition => Set<EDITION>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DataBaseLaba8;Integrated Security=True");
        }
    }
}
