using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // dbcontext için ekledik...
using Sy.Core.Entities;

namespace Sy.DataAccess
{
    class StokDbContext : DbContext
    {
        public StokDbContext()
            : base ("name = MyCon")
        {

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product> Clients { get; set; }
    }
}
