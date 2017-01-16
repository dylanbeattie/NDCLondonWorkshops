using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreApp01 {
    public class Startup {
        private readonly IHostingEnvironment environment;

        public Startup(IHostingEnvironment environment) {
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder app) {
            app.UseLogging(new LoggingOptions() { Message = "DylanLog" });
            app.UseStaticFiles();
            app.UseMvc();
            app.Run(ctx => ctx.Response.WriteAsync("Hello World!"));
        }
    }
}