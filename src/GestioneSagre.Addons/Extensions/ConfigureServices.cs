using GestioneSagre.Email.Services;
using GestioneSagre.Email.Services.Interfaces;
using GestioneSagre.Image.Services;
using GestioneSagre.Image.Services.Interfaces;
using GestioneSagre.Tools.TransactionLog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.Addons.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT
        //services.Scan(scan => scan.FromAssemblyOf<EfCoreFestaService>()
        //    .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
        //    .AsImplementedInterfaces()
        //    .WithTransientLifetime());

        // Services SINGLETON
        services.AddSingleton<IEmailSenderService, MailKitEmailSender>();
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();
        services.AddSingleton<ITransactionLogger, LocalTransactionLogger>();

        return services;
    }
}