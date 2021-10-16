using System;
using Maya.BulkGate.Sms.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Maya.BulkGate.Sms.Extension.Microsof.DependencyInjection
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Add Maya.BulkGate.Sms.IClient service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddMayaBulkGateSms(this IServiceCollection services, Action<IServiceProvider, IConfig> configureOptions)
        {
            services.AddOptions<IConfig>()
                .Configure<IServiceProvider>((options, resolver) => configureOptions(resolver, options))
                .PostConfigure(options =>
                {
                    if (string.IsNullOrWhiteSpace(options.ApplicationId))
                    {
                        throw new ArgumentNullException(nameof(options.ApplicationId));
                    }
                    if (string.IsNullOrWhiteSpace(options.ApplicationToken))
                    {
                        throw new ArgumentNullException(nameof(options.ApplicationToken));
                    }
                });

            return services.AddSingleton<IClient>(resolver => new Client(resolver.GetRequiredService<IConfig>()));
        }

        /// <summary>
        /// Add Maya.BulkGate.Sms.IClient service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddMayaBulkGateSms(this IServiceCollection services, Action<IConfig> configureOptions)
        {
            return services.AddMayaBulkGateSms((_, options) => configureOptions(options));
        }

        /// <summary>
        /// Add Maya.BulkGate.Sms.IClient service
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddMayaBulkGateSms(this IServiceCollection services, IConfiguration configuration)
        {
            IConfig config = new Config();
            configuration.GetSection("MayaBulkGateSms").Bind(config);

            if (string.IsNullOrWhiteSpace(config.ApplicationId))
            {
                throw new ArgumentNullException(nameof(config.ApplicationId));
            }

            if (string.IsNullOrWhiteSpace(config.ApplicationToken))
            {
                throw new ArgumentNullException(nameof(config.ApplicationToken));
            }

            return services.AddSingleton<IClient>(_ => new Client(config));
        }
    }
}
