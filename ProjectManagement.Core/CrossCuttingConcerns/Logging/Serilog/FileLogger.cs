using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManagement.Core.Utilities.IoC;
using Serilog;
using Serilog.Events;

namespace ProjectManagement.Core.CrossCuttingConcerns.Logging.Serilog
{
    public class FileLogger : LoggerServiceBase
    {
        private IConfiguration _configuration;
        public FileLogger()
        {
            _configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var logConfig = _configuration.GetSection("SeriLogConfigurations:FileLogConfiguration")
                                .Get<FileLogConfiguration>() ??
                            throw new Exception(SerilogMessages.NullOptionsMessage);

            var logFilePath = string.Format("{0}{1}", Directory.GetCurrentDirectory()  /*logConfig.FolderPath, */, "/Logs/log.txt");

            Logger = new LoggerConfiguration()
                .WriteTo.File(
                    logFilePath,
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null,
                    fileSizeLimitBytes: 5000000,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}").CreateLogger();
        }
    }
}
