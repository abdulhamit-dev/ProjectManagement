using ProjectManagement.Core.CrossCuttingConcerns.Logging;
using ProjectManagement.Core.CrossCuttingConcerns.Logging.Serilog;
using ProjectManagement.Core.Utilities.Interceptors;
using ProjectManagement.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Aspects.Logging
{
    public class LogAspect: MethodInterception
    {   
        private LoggerServiceBase _loggerServiceBase;
        private IHttpContextAccessor _httpContextAccessor;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception("Wrong Logger Type");
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
           _httpContextAccessor= ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity;
            var request=_httpContextAccessor.HttpContext.Request;
            var jsonLogDetail = JsonConvert.SerializeObject(GetLogDetail(invocation));

            _loggerServiceBase.Info($"User Name : {identity.Name} , Path : {request.Path} ",jsonLogDetail);
        }
        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity;
           
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetail = new LogDetail
            {
                User=identity.Name,
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
