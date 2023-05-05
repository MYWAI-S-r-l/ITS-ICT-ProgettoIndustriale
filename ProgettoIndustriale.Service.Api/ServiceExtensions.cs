using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace ProgettoIndustriale.Service.Api;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services, string policyName, string[] allowedUrlsForCors)
    {
        services.AddCors(o => o.AddPolicy(policyName, builder =>
        {
            builder
                //.WithOrigins("https://webapp.dominio.com/", "https://localhost:1234/")
                .WithOrigins(allowedUrlsForCors)
                //.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithHeaders();
        }));
    }

    public static void ConfigureAuthentication(this IServiceCollection services, string authority, string signingKey)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey))
                };
            });
    }

    public static void ConfigureAuthorizationScope(this IServiceCollection services, string policyName, string requiredScope)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireAssertion(context => context.User.HasClaim(claim => claim.Type == "scope" && claim.Value.Split(" ").Contains(requiredScope)));
            });
        });
    }
}
