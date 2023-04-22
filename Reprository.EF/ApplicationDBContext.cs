using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reprository.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Reprository.EF
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-6UOGSN3;Initial Catalog=E-Commerce;Integrated Security=True; trust server certificate = true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
            //{
            //    relation.DeleteBehavior = DeleteBehavior.NoAction;
            //}

            

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MainProduct>().HasData(new[]
             {
                 new MainProduct
                     {
                            Id = 1,
                            Name = "Samsung Galaxy A03",
                            BrandName="Samsung",
                            Description="jkjkljkjrijklwjejijijwkr",
                            Price=3000,
                            Quantity=500,
                            RateValue=(Stars)3,
                            IsDeleted=false,
                            
                           
                     },

                 new MainProduct
                     {
                            Id = 2,
                            Name = "Nokia C31 4G Smartphone",
                            BrandName="Nokia",
                            Description="jlkmmd;lqwkdoiwuiedyqhdjoweklfh",
                            Price=4000,
                            Quantity=400,
                            RateValue=(Stars)4,
                            IsDeleted=false
                     }

            });
            modelBuilder.Entity<Mobile>().HasData(new[]
             {
                 new Mobile
                     {
                          MainProductId=1,
                            BatteryLife=13,
                           HasBackCamera=true,
                            HasFingerprintScanner=true,
                            HasBluetooth=true,
                             HasFrontCamera=true,
                             HasNFC=true,
                             IsWaterproof=true,
                             NumberOfCamera=3,
                             NumSIMCards=3,
                             RAM=3,
                             ScreenSize=6.5,
                            Screentype=ScreenType.IPS,
                            StorageCapacity=32,
                            Weight=140,
                            OperatingSystem="ios"

                     },

                 new Mobile
                     {
                            MainProductId=2,
                            BatteryLife=7,
                           HasBackCamera=true,
                            HasFingerprintScanner=true,
                            HasBluetooth=true,
                             HasFrontCamera=true,
                             HasNFC=true,
                             IsWaterproof=true,
                             NumberOfCamera=3,
                             NumSIMCards=3,
                             RAM=3,
                             ScreenSize=6.5,
                            Screentype=ScreenType.IPS,
                            StorageCapacity=32,
                            Weight=140,
                            OperatingSystem="ios"
                     }

            });

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public DbSet<MainProduct> Products { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<TV> TVs { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Clothing> Cloths { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Rate> Rates { get; set; }
    }
}
