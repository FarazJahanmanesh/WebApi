using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Application.Api.Configuration;
public static class IdentityConfiguration
{
    public static IServiceCollection AddCustomIdentity(this IServiceCollection services , IdentitySetting setting)
    {
        services.AddIdentity<User, Role>(identityOptions =>
        {
            identityOptions.Password.RequiredLength = setting.PasswordRequiredLength;
            identityOptions.Password.RequiredUniqueChars = setting.PasswordRequiredUniqueChars;
            identityOptions.Password.RequireLowercase = setting.PasswordRequireLowercase;
            identityOptions.Password.RequireDigit = setting.PasswordRequireDigit;
            identityOptions.Password.RequireUppercase = setting.PasswordRequireUppercase;

            identityOptions.User.RequireUniqueEmail = setting.UserRequireUniqueEmail;
        }).AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
        return services;
    }
}