using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Core.CrossCuttingConcerns.Caching;
using ProjectManagement.Core.Utilities.Interceptors;
using ProjectManagement.Core.Utilities.IoC;

namespace ProjectManagement.Core.Aspects.Autofac.Caching
{
    public class CacheRemoveAspect : MethodInterception
    {
        private string _pattern;
        private ICacheManager _cacheManager;

        public CacheRemoveAspect(string pattern)
        {
            _pattern = pattern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_pattern);
        }
    }
}
