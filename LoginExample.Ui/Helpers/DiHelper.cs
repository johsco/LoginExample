using LoginExample.Interfaces;
using LoginExample.Interfaces.Managers;
using LoginExample.Interfaces.Repositories;
using LoginExample.Managers;
using LoginExample.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LoginExample.Helpers
{
    public static class DiHelper
    {
        public static void RegisterContainers(IServiceCollection services)
        {
            services.AddSingleton<IAppSettings, AppSettings>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            //Managers
            services.AddScoped<IUserManager, UserManager>();
        }   
    }
}