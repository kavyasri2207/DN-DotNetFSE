using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace EmployeeWebApi.Filters
{
    // Task 3: Custom Exception filter
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Use the exception context to fetch the exception detail
            var exceptionMessage = context.Exception.Message;
            
            // Capture that and write it to a File in the system
            string logPath = "ExceptionLog.txt";
            File.AppendAllText(logPath, $"[{DateTime.Now}] Caught Exception: {exceptionMessage}\n");

            // Assignment Note: Set Result property to ExceptionResult
            // Note: Since 'ExceptionResult' from WebApiCompatShim causes breaking conflicts in modern .NET 8,
            // we use the modern ASP.NET Core equivalent 'ObjectResult' while returning a 500 status code.
            context.Result = new ObjectResult(new { Error = "Internal Server Error", Details = exceptionMessage })
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}
