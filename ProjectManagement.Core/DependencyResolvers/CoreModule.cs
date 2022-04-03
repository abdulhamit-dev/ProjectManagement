using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Core.Utilities.IoC;

namespace ProjectManagement.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
