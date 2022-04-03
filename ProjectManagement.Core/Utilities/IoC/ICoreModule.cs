using Microsoft.Extensions.DependencyInjection;

namespace ProjectManagement.Core.Utilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection collection);
    }
}
