using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Issue> Issues { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}