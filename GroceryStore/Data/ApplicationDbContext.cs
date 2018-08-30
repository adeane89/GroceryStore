using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroceryStore.Models;

namespace GroceryStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<GroceryProductsModel> GroceryProduct { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<GroceryProductCart> GroceryProductCart { get; set; }
        public DbSet<GroceryCartProduct> GroceryCartProducts { get; set; }


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


            builder.Entity<CategoryModel>().HasKey(x => x.Name);
            builder.Entity<CategoryModel>().Property(x => x.DateCreated).HasDefaultValueSql("GetDate()");
            builder.Entity<CategoryModel>().Property(x => x.DateLastModified).HasDefaultValueSql("GetDate()");
            builder.Entity<CategoryModel>().Property(x => x.Name).HasMaxLength(100);

            builder.Entity<ApplicationUser>().HasOne(x => x.GroceryProductCart).WithOne(x => x.ApplicationUser).HasForeignKey<GroceryProductCart>(x => x.ApplicationUserID);
        }
    }
}
