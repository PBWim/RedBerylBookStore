﻿namespace RedBerylBookStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using ServiceModels;
    using Service.Contract;
    using Shared.Domain;

    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ILogger<AccountController> logger;
        private readonly IConfiguration configuration;

        public AccountController(IUserService userService, IMapper mapper, ILogger<AccountController> logger,
            IConfiguration configuration)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("api/Account/Login")]
        public async Task<ActionResult> Login([FromBody]LoginModel model)
        {
            if (model == null)
            {
                this.logger.LogWarning($"The Account {nameof(this.Login)} action has been accessed with Invalid User Model");
                return BadRequest(ApiResponse.BadRequest("Invalid User Model"));
            }

            if (ModelState.IsValid)
            {
                this.logger.LogInformation($"The Account {nameof(this.Login)} action has been accessed with User Model : {model}");
                var result = await this.userService.SignIn(model.Email, model.Password);
                if (result)
                {
                    this.logger.LogInformation($"JWT Token created User Model : {model}");
                    var user = this.userService.Get(true).FirstOrDefault(x => x.Email == model.Email);
                    var tokenString = this.GenerateJSONWebToken(user);
                    return Ok(ApiResponse.OK(new { accessToken = tokenString, loggedUser = user }));
                }
                this.logger.LogWarning($"Invalid User Login of User Model : {model}");
                return BadRequest(ApiResponse.BadRequest("Invalid User Login"));
            }

            this.logger.LogWarning($"The Account {nameof(this.Login)} action has been accessed with Invalid User Model");
            return BadRequest(ApiResponse.BadRequest("Invalid User Model"));
        }

        [HttpPost]
        [Route("api/Account/Register")]
        public async Task<ActionResult> Register([FromBody]UserModel model)
        {
            if (model == null)
            {
                this.logger.LogWarning($"The Account {nameof(this.Register)} action has been accessed with Invalid User Model");
                return BadRequest(ApiResponse.BadRequest("Invalid User Model"));
            }

            if (ModelState.IsValid)
            {
                var userObj = this.mapper.Map<User>(model);
                var result = await this.userService.Create(userObj);
                if (result.Succeeded)
                {
                    this.logger.LogInformation($"User created successfully : {userObj}");
                    return this.Ok(true);
                }
                else if (result.Errors.Any())
                {
                    this.logger.LogWarning($"User did not get created : {userObj}");
                    return this.BadRequest(result.Errors);
                }
            }

            this.logger.LogWarning($"The Account {nameof(this.Register)} action has been accessed with Invalid User Model");
            return BadRequest(ApiResponse.BadRequest("Invalid User Model"));
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            this.logger.LogInformation($"Generate JWT Token for User {userInfo}");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(this.configuration["Jwt:Issuer"],
              this.configuration["Jwt:Issuer"],
              new List<Claim>() {
                  new Claim(ClaimTypes.Name, $"{userInfo.FirstName} {userInfo.LastName}"),
                  new Claim(ClaimTypes.Email, userInfo.Email),
                  new Claim(ClaimTypes.Role, userInfo.Role.ToString())
              },
              expires: DateTime.Now.AddMinutes(120), // 2 hours
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}