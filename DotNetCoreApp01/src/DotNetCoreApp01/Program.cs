using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace DotNetCoreApp01 {
    public class Program {
        public static void Main(string[] args) {
            var builder = new WebHostBuilder()
                .UseUrls("http://localhost:5000")
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>();

            var server = builder.Build();
            server.Start();
            Console.WriteLine("Running server...");
            Console.ReadKey(false);
        }
    }

    public class Startup {
        public void Configure(IApplicationBuilder app) {
            app.Use(async (ctx, next) => {
                Console.WriteLine(ctx.Request.Path);
                await next();
            });
            app.UseStaticFiles();
            app.Run(ctx => ctx.Response.WriteAsync("Hello World!"));
        }
    }
}
