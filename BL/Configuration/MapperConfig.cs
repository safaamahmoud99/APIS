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
    public class AutoMapperProfile : Profile
    {
        public static IMapper mapp { get; set; }
        public AutoMapperProfile()
        {

            var config = new MapperConfiguration(
            cfg =>
            {

                cfg.CreateMap<Cart, CartViewModel>().ReverseMap();
                cfg.CreateMap<WishList, WishListViewModel>().ReverseMap();
                cfg.CreateMap<User, LoginViewModel>().ReverseMap();
                cfg.CreateMap<User, RegisterationViewModel>().ReverseMap();
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

