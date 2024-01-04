using Microsoft.Extensions.DependencyInjection;
using Singleton.Caching;
using Singleton.Logger;

namespace Singleton;

public static class ConfigureServices
{
    public static IServiceCollection AddSingletonServices(this IServiceCollection services)
    {
        services.AddSingleton<IMyLogger, MyLogger>(_ => MyLogger.GetLoggerInstance);
        services.AddSingleton<IMyCache, SingletonCache>(_ => SingletonCache.GetInstance());
        
        return services;
    }
}
