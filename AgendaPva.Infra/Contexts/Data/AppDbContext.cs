using AgendaPva.Core.Contexts.AccountContext.Entities;
using AgendaPva.Core.Contexts.CompanyContext.Entities;
using AgendaPva.Infra.Contexts.AccountContext.Mappings;
using AgendaPva.Infra.Contexts.CompanyContext.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaPva.Infra.Contexts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext()
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
        }
    }
}
