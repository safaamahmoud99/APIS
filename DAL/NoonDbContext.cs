using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer("Data Source=.;Initial Catalog=NoonEcommerceWebsite;Integrated Security=True"
            , options => options.EnableRetryOnFailure());
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Brands> brands { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<CartProduct> cartProducts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Images> images { get; set; }
        public DbSet<MainCategory> mainCategories { get; set; }
        public DbSet<Offer> offers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetails> orderDetails { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<Suppliers> suppliers { get; set; }
        public DbSet<WishList> wishLists { get; set; }
        public DbSet<WishListProduct> wishListProducts { get; set; }
    }
        public class ApplicationUserStore : UserStore<User>
        {
            public ApplicationUserStore() : base(new ApplicationDbContext())
            {

            }
            public ApplicationUserStore(DbContext db) : base(db)
            {

            }
        }
}

