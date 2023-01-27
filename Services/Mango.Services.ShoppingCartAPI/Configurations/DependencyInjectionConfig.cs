namespace Mango.Services.ShoppingCartAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}