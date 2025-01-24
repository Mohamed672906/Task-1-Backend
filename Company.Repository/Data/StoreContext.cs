using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository.Data
{
    public class StoreContext : DbContext
    {

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        }

        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
