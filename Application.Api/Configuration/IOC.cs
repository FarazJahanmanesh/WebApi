using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Persistence.Repositories;

namespace Application.Api.Configuration;
public static class IOC
{
    public static IServiceCollection RegisterIOC(this IServiceCollection services)
    {
        services.RegisterRepositories()
        .RegisterServices();
        return services;
    }
    private static IServiceCollection RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}
