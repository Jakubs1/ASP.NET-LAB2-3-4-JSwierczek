using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace Lab2.Middleware
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseElapsedTimeMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ElapsedTimeMiddleware>();
        }

    }
}
