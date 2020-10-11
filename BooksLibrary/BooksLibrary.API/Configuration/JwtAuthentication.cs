using BooksLibrary.API.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BooksLibrary.API.Configuration
{
    public static class JwtAuthentication
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new JwtTokenAuth().GetSymmetricSecurityKey(),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }
    }
}
