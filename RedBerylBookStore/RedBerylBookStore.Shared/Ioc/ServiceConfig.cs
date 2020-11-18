namespace RedBerylBookStore.Shared.Ioc
{
    using Data.Contract;
    using Data.Implementation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.Extensions.DependencyInjection;
    using Service.Contract;
    using Service.Implementation;
    using Shared.Auth;

    public static class ServiceConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorizationHandler, RolesAuthorizationHandler>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }
    }
}