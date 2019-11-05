using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment _)
        {
            app.Run(async context =>
            {
                var message = Environment.GetEnvironmentVariable("NAME");

                message += $"scheme: {context.Request.Scheme} - host: {context.Request.Host} - path: {context.Request.Path}";
                message += Environment.NewLine;

                foreach(var header in context.Request.Headers)
                {
                    message += $"{header.Key} : {header.Value}";
                    message += Environment.NewLine;
                }

                await context.Response.WriteAsync(message);
            });
        }
    }
}
