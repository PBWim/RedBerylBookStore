namespace RedBerylBookStore.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Enums;
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Service.Contract;
    using Shared.Domain;

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;
        private readonly ILogger<UserController> logger;

        public UserController(IUserService userService, IMapper mapper, ILogger<UserController> logger)
        {
            this.userService = userService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Administrator))]
        [Route("api/User/GetAuthors")]
        public ActionResult GetAuthors()
        {
            this.logger.LogInformation($"The User {nameof(this.GetAuthors)} action has been accessed");
            var authors = this.userService.Get(false);
            var usersObj = authors.ProjectTo<UserModel>(this.mapper.ConfigurationProvider);
            return Ok(ApiResponse.OK(new { usersObj }));
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Administrator))]
        [Route("api/User/ActivateAuthor")]
        public async Task<ActionResult> ActivateAuthor([FromQuery] int userId)
        {
            if (userId <= 0)
            {
                this.logger.LogWarning($"The Account {nameof(this.ActivateAuthor)} action has been accessed with Invalid User Id : {userId}");
                return BadRequest(ApiResponse.BadRequest("Invalid User Id"));
            }

            this.logger.LogInformation($"The User {nameof(this.ActivateAuthor)} action has been accessed");
            var result = await this.userService.Update(userId, true);
            if (result.Succeeded)
            {
                this.logger.LogInformation($"The User : {userId} action has been activated");
                return Ok(ApiResponse.OK(true));
            }
            this.logger.LogInformation($"The User : {userId} action has not been activated");
            return BadRequest(ApiResponse.BadRequest("User Activation failed"));
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Administrator))]
        [Route("api/User/DeactivateAuthor")]
        public async Task<ActionResult> DeactivateAuthor([FromQuery] int userId)
        {
            if (userId <= 0)
            {
                this.logger.LogWarning($"The Account {nameof(this.DeactivateAuthor)} action has been accessed with Invalid User Id : {userId}");
                return BadRequest(ApiResponse.BadRequest("Invalid User Id"));
            }

            this.logger.LogInformation($"The User {nameof(this.DeactivateAuthor)} action has been accessed");
            var result = await this.userService.Update(userId, false);
            if (result.Succeeded)
            {
                this.logger.LogInformation($"The User : {userId} action has been deactivated");
                return Ok(ApiResponse.OK(true));
            }
            this.logger.LogInformation($"The User : {userId} action has not been deactivated");
            return BadRequest(ApiResponse.BadRequest("User Deactivation failed"));
        }
    }
}