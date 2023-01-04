using Business.Contract.Services.UrlItemManagement;
using Business.Contract.Services.UserManagement;
using Business.Services.UrlManagement;
using Business.Services.UserManagement;
using Data.Contract.UnitOfWork;
using Data.Identity.Data;
using Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthentificationUnitOfWork, AuthentificationUnitOfWork>();

            //add here new services
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddTransient<IProfileManager, ProfileManager<AuthorisationUser>>();
            services.AddTransient<IProfileDataService, ProfileDataService>();
            services.AddTransient<IProfileRegistrationService, ProfileRegistrationService>();

            services.AddTransient<IUrlItemService, UrlItemService>();

            return services;
        }
    }
}
