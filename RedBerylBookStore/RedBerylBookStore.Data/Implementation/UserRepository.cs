namespace RedBerylBookStore.Data.Implementation
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Enums;
    using Common.SystemConstants;
    using Contract;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using RedBerylBookStore.ServiceModels;
    using DO = DataModels;

    public class UserRepository : IUserRepository
    {
        private readonly ILogger<UserRepository> logger;
        private readonly UserManager<DO.User> userManager;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public UserRepository(UserManager<DO.User> userManager, IMapper mapper,
            ApplicationDbContext context, ILogger<UserRepository> logger)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.context = context;
            this.logger = logger;
        }

        public IQueryable<User> Get(bool isAll)
        {
            this.logger.LogInformation($"Get users on {nameof(Get)} in UserRepository with isAll : {isAll}");
            var users = isAll ? this.context.Users : this.context.Users.Where(x => x.Role == UserRole.Author);
            var usersList = users.ProjectTo<User>(this.mapper.ConfigurationProvider);
            return usersList;
        }

        public async Task<IdentityResult> Create(User user)
        {
            this.logger.LogInformation($"Create user on {nameof(Create)} in UserRepository with user details : {user}");
            var userObj = this.mapper.Map<DO.User>(user);
            var adminUser = await this.userManager.FindByEmailAsync(Constants.SuperUserEmail);
            userObj.LastModifiedBy = adminUser.Id;
            userObj.LastModifiedOn = DateTime.UtcNow;
            var result = await this.userManager.CreateAsync(userObj, userObj.PasswordHash);
            return result;
        }

        public async Task<IdentityResult> Update(User user)
        {
            this.logger.LogInformation($"Update user on {nameof(Update)} in UserRepository with user details : {user}");
            var userObj = this.mapper.Map<DO.User>(user);
            var result = await userManager.UpdateAsync(userObj);
            return result;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            this.logger.LogInformation($"User sign in on {nameof(SignIn)} in UserRepository with Email : {email}");
            var userObj = await this.userManager.FindByEmailAsync(email);
            var isValid = await this.userManager.CheckPasswordAsync(userObj, password);
            return isValid;
        }
    }
}