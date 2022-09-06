using Microsoft.OpenApi.Models;
using Schedule.Application.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Schedule.API.Extentions
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void AddSecurityConfiguration(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("https://localhost:5001/connect/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            {SwaggerConfiguration.Scope, SwaggerConfiguration.ScopeDescription}
                        }
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = SwaggerConfiguration.OpenApiReferenceId
                        },
                        Scheme = SwaggerConfiguration.Scheme,
                        Name = SwaggerConfiguration.SchemeName,
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        }
    }
}
