using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;


namespace NamaaWebSite.Helpers
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
             catch (Exception ex)
            {
                // Handle the exception
                // Log the error, customize the response, etc.
                // Example: Return a JSON response with the error message
                System.IO.Directory.CreateDirectory("C:\\NamaaWebSitLogging");
                string fileName = $@"C:\Logging\Log_application_{DateTime.UtcNow.Ticks}";
                FileStream objFilestream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
                StreamWriter objStreamWriter = new StreamWriter(objFilestream);
                objStreamWriter.WriteLine($"The exception message is >> {ex?.Message!} >>>>> {DateTime.UtcNow:dddd, dd MMMM yyyy HH:mm} \n\n\n ");
                objStreamWriter.WriteLine($"\n\nThe exception stack trace is >> {ex?.StackTrace!}");
                objStreamWriter.Close();
                objFilestream.Close();

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var errorMessage = "An error occurred.";
                await context.Response.WriteAsync($"{{ \"error\": \"{errorMessage}\" }}");
            }
        }
    }
}