using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using ProjectManagement.Core.Exceptions;
using System.Net;

namespace ProjectManagement.Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";

            if (e.GetType() == typeof(UnAuthorizeException))
            {
                message = e.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            IEnumerable<ValidationFailure> errors;
            if (e.GetType() == typeof(ValidationException))
            {
                message = ((ValidationException)e).Errors.Select(x => x.ErrorMessage).FirstOrDefault();
                errors = ((ValidationException)e).Errors;
                httpContext.Response.StatusCode = 400;

                return httpContext.Response.WriteAsync(new ErrorDetails
                {
                    StatusCode = 400,
                    Message = message
                }.ToString());
            }
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
