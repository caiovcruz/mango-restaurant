using Microsoft.IdentityModel.Tokens;

namespace Mango.Services.ShoppingCartAPI.Configurations
{
    public static class AuthConfig
    {
        public static void AddAuthConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.Authority = configuration.GetValue<string>("IdentityServerUrl");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "mango");
                });
            });
        }
    }
}