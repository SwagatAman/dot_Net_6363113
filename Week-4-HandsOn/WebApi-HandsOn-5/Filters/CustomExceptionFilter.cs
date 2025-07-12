using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System;

namespace YourNamespace.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly string _logFilePath = "error_log.txt";

        public void OnException(ExceptionContext context)
        {
            var exceptionDetails = $"Timestamp: {DateTime.UtcNow}\n" +
                                   $"Exception Type: {context.Exception.GetType().Name}\n" +
                                   $"Message: {context.Exception.Message}\n" +
                                   $"StackTrace: {context.Exception.StackTrace}\n\n";

            File.AppendAllText(_logFilePath, exceptionDetails);

            context.Result = new ExceptionResult(context.Exception, enableDebugMode: true)
            {
                StatusCode = 500,
                Value = new {
                    StatusCode = 500,
                    Message = "An internal server error occurred.",
                    DetailedMessage = context.Exception.Message
                }
            };

            context.ExceptionHandled = true;
        }
    }
}