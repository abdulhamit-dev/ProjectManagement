using ProjectManagement.UI.Services;

namespace ProjectManagement.UI.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration.GetValue<string>("BaseUrl");
            services.AddHttpClient<AuthService>(opt => { opt.BaseAddress = new Uri(baseUrl); });
            services.AddHttpClient<ProjectService>(opt => { opt.BaseAddress = new Uri(baseUrl); });
        }
    }
}
