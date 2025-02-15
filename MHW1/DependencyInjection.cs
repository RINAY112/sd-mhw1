using Microsoft.Extensions.DependencyInjection;
using MHW1.Services.Abstractions;
using MHW1.Services;

namespace MHW1;

public static class DependencyInjection
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddScoped<IVeterinaryClinic, VeterinaryClinic>();
        services.AddScoped<IZooService, ZooService>();

        return services.BuildServiceProvider();
    }
}
