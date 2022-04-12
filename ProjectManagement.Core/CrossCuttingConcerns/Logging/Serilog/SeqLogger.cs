using ProjectManagement.Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace ProjectManagement.Core.CrossCuttingConcerns.Logging.Serilog
{
    public class SeqLogger: LoggerServiceBase
    {
        private IConfiguration _configuration;
        public SeqLogger()
        {
            _configuration= ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var serilogCon = _configuration.GetSection("SeriLogConfigurations:SeqConfiguration")
                                .Get<SeqLogConfigration>();

            Logger = new LoggerConfiguration()
                .WriteTo.Seq(serilogCon.Url)
                 .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .Enrich.WithProperty("AppName", "ProjectManagement")
                .Enrich.WithProperty("Environment", "development")
                .CreateLogger();
        }
    }
}
