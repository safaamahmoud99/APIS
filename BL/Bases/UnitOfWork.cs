using BL.interfaces;
using BL.Repository;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bases
{
   public class UnitOfWork : IUnitOfWork
    {
        private DbContext EC_DbContext { get; set; }
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UnitOfWork(ApplicationDbContext EC_DbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this.EC_DbContext = EC_DbContext;
        }
        public int Commit()
        {
            return EC_DbContext.SaveChanges();
        }
        public void Dispose()
        {
            EC_DbContext.Dispose();
        }

        public CartRepository cart;
        public CartRepository Cart
        {
            get
            {
                if (cart == null)
                    cart = new CartRepository(EC_DbContext);
                return cart;
            }
        }
        public WishListRepository wishlist;
        public WishListRepository WishList
        {
            get
            {
                if (wishlist == null)
                    wishlist = new WishListRepository(EC_DbContext);
                return wishlist;
            }
        }
        public AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                if (account == null)
                    account = new AccountRepository(EC_DbContext, _userManager, _roleManager);
                return account;
            }
        }
        public BrandRepository brand;
        public BrandRepository Brand
        {
            get
            {
                if (brand == null)
                    brand = new BrandRepository(EC_DbContext);
                return brand;
            }
        }
        public SupplierRepository supplier;
        public SupplierRepository Supplier
        {
            get
            {
                if (supplier == null)
                    supplier = new SupplierRepository(EC_DbContext);
                return supplier;
            }
        }
        public ImageRepository image;
        public ImageRepository Image
        {
            get
            {
                if (image == null)
                    image = new ImageRepository(EC_DbContext);
                return image;
            }
        }
        public OrderRepository order;
        public OrderRepository Order
        {
            get
            {
                if (order == null)
                   order = new OrderRepository(EC_DbContext);
                return order;
            }
        }
        public OfferRepository offer;
        public  OfferRepository Offer
        {
            get
            {
                if (offer == null)
                    offer = new OfferRepository(EC_DbContext);
                return offer;
            }
        }
        public OrderDetailsRepository orderdetails;
        public OrderDetailsRepository Orderdetails
        {
            get
            {
                if (orderdetails == null)
                    orderdetails = new OrderDetailsRepository(EC_DbContext);
                return orderdetails;
            }
        }





    }
}

