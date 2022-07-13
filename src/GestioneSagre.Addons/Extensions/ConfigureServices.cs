using GestioneSagre.Email.Services;
using GestioneSagre.Email.Services.Interfaces;
using GestioneSagre.Image.Services;
using GestioneSagre.Image.Services.Interfaces;
using GestioneSagre.Tools.TransactionLog;
using GestioneSagre.Upload.UploadLogo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestioneSagre.Addons.Extensions;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Services TRANSIENT - GestioneSagre.Upload
        services.Scan(scan => scan.FromAssemblyOf<EfCoreLogoService>()
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        // Services TRANSIENT - GestioneSagre.Application

        // Services SINGLETON
        services.AddSingleton<IEmailSenderService, MailKitEmailSender>();       //GestioneSagre.Email
        services.AddSingleton<IImagePersister, MagickNetImagePersister>();      //GestioneSagre.Image
        services.AddSingleton<ITransactionLogger, LocalTransactionLogger>();    //GestioneSagre.Tools

        return services;
    }
}