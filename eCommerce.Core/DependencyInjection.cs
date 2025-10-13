namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the dipendency injection container.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddTransient<IApplicationUserService, ApplicationUserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
        return services;
    }
}
