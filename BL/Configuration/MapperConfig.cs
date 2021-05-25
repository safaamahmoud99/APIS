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
        public AutoMapperProfile()
        {
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<WishList, WishListViewModel>().ReverseMap();
            CreateMap<User, LoginViewModel>().ReverseMap();
            CreateMap<User, RegisterationViewModel>().ReverseMap();
            CreateMap<Brands, BrandViewModel>().ReverseMap();
            CreateMap<Suppliers, SupplierViewModel>().ReverseMap();
            CreateMap<Images, ImageViewModel>().ReverseMap();
            CreateMap<CartProduct, CartProductViewModel>().ReverseMap();


        }
    }
}
