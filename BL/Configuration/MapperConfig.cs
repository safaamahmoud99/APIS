using AutoMapper;
using BL.DTOs;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Configuration
{
    public class AutoMapperProfile
    {
        public static IMapper mapp { get; set; }
         static AutoMapperProfile()
        {

            var config = new MapperConfiguration(
            cfg =>
            {
                cfg.CreateMap<Cart, CartViewModel>().ReverseMap();
                cfg.CreateMap<Offer, OfferViewModel>().ReverseMap();
                cfg.CreateMap<WishList, WishListViewModel>().ReverseMap();
                cfg.CreateMap<User, LoginViewModel>().ReverseMap();
                cfg.CreateMap<OrderDetails, OrderDetailsViewModel>().ReverseMap();
                cfg.CreateMap<Order, OrderViewModel>().ReverseMap();
                cfg.CreateMap<User, RegisterationViewModel>().ReverseMap();
                //.ForMember(u => u.Email, v => v.MapFrom(c => c.Email));
                cfg.CreateMap<Brands, BrandViewModel>().ReverseMap();
                cfg.CreateMap<Suppliers, SupplierViewModel>().ReverseMap();
                cfg.CreateMap<Images, ImageViewModel>().ReverseMap();
                cfg.CreateMap<CartProduct, CartProductViewModel>().ReverseMap();
                cfg.CreateMap<WishListProduct, WishListProductViewModel>().ReverseMap();
                cfg.CreateMap<Review, ReviewViewModel>().ReverseMap();


            });
            mapp = config.CreateMapper();

        }
    }
}

