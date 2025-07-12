using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System;

namespace YourNamespace.Filters // Use your actual namespace
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly string _logFilePath = "error_log.txt"; // Define your log file path

        public void OnException(ExceptionContext context)
        {
            // Log the exception details to a file
            var exceptionDetails = $"Timestamp: {DateTime.UtcNow}\n" +
                                   $"Exception Type: {context.Exception.GetType().Name}\n" +
                                   $"Message: {context.Exception.Message}\n" +
                                   $"StackTrace: {context.Exception.StackTrace}\n\n";

            File.AppendAllText(_logFilePath, exceptionDetails);

            // Set the Result property to ExceptionResult
            // ExceptionResult is part of Microsoft.AspNetCore.Mvc.WebApiCompatShim
            context.Result = new ExceptionResult(context.Exception, enableDebugMode: true)
            {
                StatusCode = 500,
                // You can customize the content of the response
                Value = new {
                    StatusCode = 500,
                    Message = "An internal server error occurred.",
                    DetailedMessage = context.Exception.Message // In production, avoid exposing too much detail
                }
            };

            // Mark the exception as handled to prevent further processing
            context.ExceptionHandled = true;
        }
    }
}