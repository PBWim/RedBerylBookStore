namespace RedBerylBookStore.Shared.Ioc
{
    using Data.Contract;
    using Data.Implementation;
    using Microsoft.Extensions.DependencyInjection;
    using Service.Contract;
    using Service.Implementation;

    public static class ServiceConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IUserService, UserService>();

            // Repository
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}