namespace RedBerylBookStore.Service.Implementation
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Contract;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using ServiceModels;
    using Service.Contract;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            this.logger = logger;
            this.userRepository = userRepository;
        }

        public IQueryable<User> Get(bool isAll = false)
        {
            this.logger.LogInformation($"Get users on {nameof(Get)} in UserService with isAll : {isAll}");
            var result = this.userRepository.Get(isAll);
            return result;
        }

        public async Task<IdentityResult> Create(User user)
        {
            this.logger.LogInformation($"Create user on {nameof(Create)} in UserService with user details : {user}");
            var result = await this.userRepository.Create(user);
            return result;
        }

        public async Task<IdentityResult> Update(int userId, bool isActivated)
        {
            this.logger.LogInformation($"Update user on {nameof(Update)} in UserService with user Id : {userId} and isActivated : {isActivated}");
            var result = await userRepository.Update(userId, isActivated);
            return result;
        }

        public async Task<IdentityResult> Update(User user)
        {
            this.logger.LogInformation($"Update user on {nameof(Update)} in UserService with user details : {user}");
            var result = await userRepository.Update(user);
            return result;
        }

        public async Task<bool> SignIn(string email, string password)
        {
            this.logger.LogInformation($"User sign in on {nameof(SignIn)} in UserService with Email : {email}");
            var result = await this.userRepository.SignIn(email, password);
            return result;
        }
    }
}