﻿using AutoMapper;
using BL.AppService;
using BL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEP_APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IConfiguration _config;
        private AccountAppService _accountAppservice;
        public AccountController(IConfiguration config, AccountAppService accountAppservice)
        {
            _config = config;
            _accountAppservice = accountAppservice;
        }
        [HttpPost("/login")]
        public async Task<IActionResult>  Login(LoginViewModel login)
        {
            IActionResult response = Unauthorized();
            var user = await _accountAppservice.Find(login.Email,login.Password);

            if (user != null)
            {
                var tokenString =  _accountAppservice.CreateToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        [AllowAnonymous]
        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterationViewModel User)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user =await  _accountAppservice.Register(User);
            if (user.Succeeded)
            {
                return Ok();
            }
            else 
            return BadRequest(user.Errors.ToList()[0]);
        }

    }
}
