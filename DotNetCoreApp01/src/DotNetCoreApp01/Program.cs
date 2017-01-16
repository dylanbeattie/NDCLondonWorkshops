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

    public class LoggingMiddleware {
        private readonly RequestDelegate next;
        private readonly LoggingOptions options;

        public LoggingMiddleware(RequestDelegate next, LoggingOptions options) {
            this.next = next;
            this.options = options;
            this.options = options;
        }

        public async Task Invoke(HttpContext context) {
            Console.WriteLine(options.Message + ": " + context.Request.Method + " " + context.Request.Path);
            await next.Invoke(context);
            Console.WriteLine(options.Message + ": " + context.Response.StatusCode);

        }
    }
}
