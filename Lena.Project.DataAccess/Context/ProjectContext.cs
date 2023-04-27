using Lena.Project.DataAccess.Configurations;
using Lena.Project.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lena.Project.DataAccess.Context
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
 
            modelBuilder.ApplyConfiguration(new FormConfiguration());
        }

 
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Form> Forms { get; set; }
    }
}
