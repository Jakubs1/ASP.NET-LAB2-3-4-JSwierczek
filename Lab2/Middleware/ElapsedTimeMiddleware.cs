using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Lab2.Middleware
{
    public class ElapsedTimeMiddleware
    {
        private RequestDelegate _next;

        public ElapsedTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext context)
        {
            var sw = new Stopwatch();
            sw.Start();
            await _next(context);

            Console.WriteLine($"{context.Request.Path} executed in { sw.ElapsedMilliseconds}ms");
        }
    }
}
