using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CardsServerD100923ER.Application.Filters
{
    public class LogActionFilter:IActionFilter
    {
        private string timestamp;
        private Stopwatch stopwatch=new Stopwatch();
        public void OnActionExecuting(ActionExecutingContext context)
        {
            timestamp = "["+DateTime.Now+"]";
            stopwatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            string path = context.HttpContext.Request.Path; //request
            string method = context.HttpContext.Request.Method; //request
            string? origin = context.HttpContext.Request.Headers["origin"].FirstOrDefault(); //request
            stopwatch.Stop();
            string responseTime = stopwatch.ElapsedMilliseconds+"ms"; //Calculated
            int statusCode=context.HttpContext.Response.StatusCode; //response

            Console.WriteLine($"{timestamp} incoming request from {origin} {path} {method} {statusCode} - {responseTime}");
        }
    }
}
