using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BL.AppService
{
    public class AccountAppService:BaseAppService
    {
        IConfiguration _configuration;
        CartAppService _cartAppService;
        WishlistAppService _wishlistAppService;
        public AccountAppService(IUnitOfWork theUnitOfWork, IConfiguration configuration,
           CartAppService cartAppService, WishlistAppService wishlistAppService, IMapper mapper) : base(theUnitOfWork, mapper)
        {
            this._configuration = configuration;
            this._cartAppService = cartAppService;
            this._wishlistAppService = wishlistAppService;
        }
    }
}
