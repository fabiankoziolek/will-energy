using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WillEnergy.WebUI.Extensions
{
    public static class OpenApiExtension
    {
        public static void AddCustomOpenApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", CreateInfoForApiVersion("v1"));

                configuration.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                        "Enter 'Bearer' [space] and then your token in the text input.",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                });

                configuration.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    },
                });
            });
        }

        public static void UseCustomOpenApi(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); });
        }

        private static OpenApiInfo CreateInfoForApiVersion(string version)
        {
            var info = new OpenApiInfo
            {
                Title = $"WillEnergy API {version}",
                Description = "Hackathon 🚀",
                Version = version,
            };

            return info;
        }
    }
}
