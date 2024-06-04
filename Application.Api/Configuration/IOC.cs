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
        return services;
    }
    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        return services;
    }
}
