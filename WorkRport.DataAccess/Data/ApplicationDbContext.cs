using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trac_WorkReport.Models;
using WorkReport.DataAccess;
using WorkReport.Models;
using WorkReport.Models.Models;

namespace WorkReport.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Add your customizations after calling base.OnModelCreating(builder);

            // Ensure the Discriminator column is correctly configured
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers")
                   .HasDiscriminator<string>("Discriminator")
                   .HasValue<ApplicationUser>("ApplicationUser");

            //builder.Entity<ApplicationUser>()
            //      .ToTable("AspNetUsers")
            //      .HasDiscriminator<string>("UserType")
            //      .HasValue<ApplicationUser>("ApplicationUser");

            // Configure additional entity mappings here if necessary
        }

        public DbSet<Designation> Designations { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<EmployeeMapping> employeeMappings { get; set; }

        public DbSet<TimeSheet> timeSheets { get; set; }
    }
}
