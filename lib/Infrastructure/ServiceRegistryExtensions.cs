namespace Infrastructure;

using Infrastructure.Concrete;
using Infrastructure.Contexts;
using Infrastructure.Interfaces;
using Infrastructure.Options;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

public static class ServiceRegistryExtensions
{
    public static IHostApplicationBuilder AddInfrastructure(this IHostApplicationBuilder builder)
    {
        var options = new InfrastructureOptions();

        builder
            .Configuration
            .Bind(InfrastructureOptions.AppConfigurationKey, options);

        builder.Services.AddDbContextPool<SimpleVMSDbContext>(opts =>
        {
            opts
            .EnableSensitiveDataLogging()
            .EnableThreadSafetyChecks()
            .EnableServiceProviderCaching()
            .EnableDetailedErrors()
            .UseSqlServer(options.ConnectionString)
            ;
        });

        builder.Services.AddScoped((sp) =>
        {
            return new SqlConnection(options.ConnectionString);
        });

        builder
            .Services
            .TryAddScoped(typeof(IRepository<>), typeof(EFRepository<>));

        return builder;
    }
}
