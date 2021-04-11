using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

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

            string message =  "Internal Server Error";

            if (e.GetType() == typeof(ValidationException))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                message = e.Message;
                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = message,
                    Errors = ((ValidationException)e).Errors
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