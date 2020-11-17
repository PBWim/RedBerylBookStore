namespace RedBerylBookStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using Models;
    using Service.Contract;

    [Route("api/[controller]")]
    [ApiController]
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
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody]LoginModel model)
        {
            if (model == null)
            {
                this.logger.LogWarning($"The Account {nameof(this.Login)} action has been accessed with Invalid User Model");
                return BadRequest("Invalid User Model");
            }

            if (ModelState.IsValid)
            {
                this.logger.LogInformation($"The Account {nameof(this.Login)} action has been accessed with User Model : {model}");
                var result = await this.userService.SignIn(model.EmailAddress, model.Password);
                if (result)
                {
                    this.logger.LogInformation($"JWT Token created User Model : {model}");
                    var tokenString = this.GenerateJSONWebToken(model);
                    return Ok(tokenString);
                }
                this.logger.LogWarning($"Invalid User Login of User Model : {model}");
                return BadRequest("Invalid User Login");
            }

            this.logger.LogWarning($"The Account {nameof(this.Login)} action has been accessed with Invalid User Model");
            return BadRequest("Invalid User Model");
        }

        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            this.logger.LogInformation($"Generate JWT Token for User {userInfo}");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(this.configuration["Jwt:Issuer"],
              this.configuration["Jwt:Issuer"],
              new List<Claim>(),
              expires: DateTime.Now.AddMinutes(120), // 2 hours
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}