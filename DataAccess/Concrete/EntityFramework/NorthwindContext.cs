using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class NorthWindContext : DbContext         // DbContext EntityFramwork nesnesidir (bağlantı).
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=;Trusted_Connection=true"); //server adresi

        }

        //public DbSet<Brand> Brand { get; set; }           //tabloları ilişkilendirme
        //public DbSet<Colour> Colour { get; set; }
        //public DbSet<Car> Car { get; set; }
    }
}
