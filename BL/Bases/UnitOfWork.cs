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
        public OfferRepository Offer
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

        public CardProductRepository cardProduct;
        public CardProductRepository CardProduct
        {
            get
            {
                if (cardProduct == null)
                    cardProduct = new CardProductRepository(EC_DbContext);
                return cardProduct;
            }
        }

        public WishListProductRepository wishListProduct;
        public WishListProductRepository WishListProduct
        {
            get
            {
                if (wishListProduct == null)
                    wishListProduct = new WishListProductRepository(EC_DbContext);
                return wishListProduct;
            }
        }


        public ReviewRepository review;
        public ReviewRepository Review
        {
            get
            {
                if (review == null)
                    review = new ReviewRepository(EC_DbContext);
                return review;
            }
        }

        ProductRepository product;
        public ProductRepository Product
        {
            get
            {
                if (product == null)
                    product = new ProductRepository(EC_DbContext);
                return product;
            }
        }

        MainCategoryRepository mainCategory;
        public MainCategoryRepository MainCategory
        {
            get
            {
                if (mainCategory == null)
                    mainCategory = new MainCategoryRepository(EC_DbContext);
                return mainCategory;
            }
        }

        public SubCategoryRepository subCategory;
        public SubCategoryRepository SubCategory
        {
            get
            {
                if (subCategory == null)
                    subCategory = new SubCategoryRepository(EC_DbContext);
                return subCategory;
            }
        }

        public CategoryRepository category;
        public CategoryRepository Category
        {
            get
            {
                if (category == null)
                    category = new CategoryRepository(EC_DbContext);
                return category;
            }
        }
        public RoleRepository role;
        public RoleRepository Role
        {
            get
            {
                if (role == null)
                    role = new RoleRepository(EC_DbContext, _roleManager);
                return role;
            }
        }
    }
}

