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
        public WishListRepository Wishlist
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

        WishListRepository IUnitOfWork.wishList => throw new NotImplementedException();
    }
}

