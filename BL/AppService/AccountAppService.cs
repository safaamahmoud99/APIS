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
using BL.interfaces;
using BL.DTOs;
using BL.StaticClasses;

namespace BL.AppService
{
    public class AccountAppService:BaseAppService
    {
        IConfiguration _configuration;
        CartAppService _cartAppService;
        WishListAppService _wishlistAppService;
        public AccountAppService(IUnitOfWork theUnitOfWork, IConfiguration configuration,
           CartAppService cartAppService, WishListAppService wishlistAppService, IMapper mapper) : base(theUnitOfWork, mapper)
        {
            this._configuration = configuration;
            this._cartAppService = cartAppService;
            this._wishlistAppService = wishlistAppService;
        }
        private void CreateUserCartAndWishlist(string userId)
        {
            _wishlistAppService.CreateUserWishlist(userId);
            _cartAppService.CreateUserCart(userId);
        }
        public List<RegisterationViewModel> GetAllAccounts()
        {
            return Mapper.Map<List<RegisterationViewModel>>(TheUnitOfWork.Account.GetAllAccounts());
        }
        public RegisterationViewModel GetAccountById(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            return Mapper.Map<RegisterationViewModel>(TheUnitOfWork.Account.GetAccountById(id));
        }
        public bool DeleteAccount(string id)
        {
            if (id == null)
                throw new ArgumentNullException();
            bool result = false;
            User user = TheUnitOfWork.Account.GetAccountById(id);
            TheUnitOfWork.Account.Update(user);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
        public async Task<User> Find(string name, string password)
        {
           User user = await TheUnitOfWork.Account.Find(name, password);
           if (user != null )
               return user;
           return null;
        }
        public async Task<User> FindByName(string userName)
        {
            User user = await TheUnitOfWork.Account.FindByName(userName);
            if (user != null )
                return user;
            return null;
        }
        public async Task<IdentityResult> AssignToRole(string userid, string rolename)
        {
            if (userid == null || rolename == null)
                return null;
            return await TheUnitOfWork.Account.AssignToRole(userid, rolename);
        }
        public async Task<bool> UpdatePassword(string userID, string newPassword)
        {
            User identityUser = await TheUnitOfWork.Account.FindById(userID);
            identityUser.PasswordHash = newPassword;
            return await TheUnitOfWork.Account.updatePassword(identityUser);
        }
        public async Task<bool> Update(RegisterationViewModel user)
        {
            User identityUser = await TheUnitOfWork.Account.FindById(user.id);
            var oldPassword = identityUser.PasswordHash;
            Mapper.Map(user, identityUser);
            identityUser.PasswordHash = oldPassword;
            return await TheUnitOfWork.Account.UpdateAccount(identityUser);
        }
        public async Task<bool> checkUserNameExist(string userName)
        {
            var user = await TheUnitOfWork.Account.FindByName(userName);
            return user == null ? false : true;
        }
        public async Task<IEnumerable<string>> GetUserRoles(User user)
        {
            return await TheUnitOfWork.Account.GetUserRoles(user);
        }
        public async Task<dynamic> CreateToken(User user)
        {
            var userRoles = await GetUserRoles(user);

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim("role",userRoles.FirstOrDefault()),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };


        }
        public async Task<IdentityResult> Register(RegisterationViewModel user)
        {
            bool isExist = await checkUserNameExist(user.FullName);
            if (isExist)
                return IdentityResult.Failed(new IdentityError
                { Code = "error", Description = "user name already exist" });

           User identityUser = Mapper.Map<RegisterationViewModel, User>(user);
            var result = await TheUnitOfWork.Account.Register(identityUser);
            // create user cart and wishlist 
            if (result.Succeeded)
            {
                CreateUserCartAndWishlist(identityUser.Id);
            }
            return result;
        }
        public async Task CreateFirstAdmin()
        {
            var firstAdmin = new RegisterationViewModel()
            {
                id = null,
                Email = "test@gmail.com",
                FullName = "admin",
                Password = "@Admin12345",
            };
            Register(firstAdmin).Wait();
            User foundedAdmin = await FindByName(firstAdmin.FullName);
            if (foundedAdmin != null)
                AssignToRole(foundedAdmin.Id, UserRoles.Admin).Wait();
        }
        public int CountEntity()
        {
            return TheUnitOfWork.Account.CountEntity();
        }
        public IEnumerable<RegisterationViewModel> GetPageRecords(int pageSize, int pageNumber)
        {
            return Mapper.Map<List<RegisterationViewModel>>(TheUnitOfWork.Account.GetPageRecords(pageSize, pageNumber));
        }
    }
}
