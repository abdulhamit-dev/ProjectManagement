using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Core.CrossCuttingConcerns.Caching;
using ProjectManagement.Core.CrossCuttingConcerns.Caching.Microsoft;
using ProjectManagement.Core.CrossCuttingConcerns.Caching.Redis;
using ProjectManagement.Core.Utilities.IoC;

namespace ProjectManagement.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            //services.AddSingleton<RedisServer>();
            //services.AddSingleton<ICacheManager, RedisCacheManager>();


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
