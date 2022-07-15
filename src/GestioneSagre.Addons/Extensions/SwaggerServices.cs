﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GestioneSagre.Addons.Extensions;

public static class SwaggerServices
{
    public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration, string ExternalXmlPath)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Gestione Sagre",
                Version = "v1",
                Description = "API that allows the management of festivals management",

                Contact = new OpenApiContact
                {
                    Name = "Angelo Pirola",
                    Email = "angelo@aepserver.it",
                    Url = new Uri("https://about.me/AngeloPirola"),
                },

                License = new OpenApiLicense
                {
                    Name = "Licenza MIT",
                    Url = new Uri("https://it.wikipedia.org/wiki/Licenza_MIT"),
                }
            });

            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            //config.IncludeXmlComments(xmlPath);
            config.IncludeXmlComments(ExternalXmlPath);
        });

        return services;
    }
}