using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreApp01 {
    public class Startup {
        private readonly IHostingEnvironment environment;

        public Startup(IHostingEnvironment environment) {
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services) {

            var defaultPolicy =
                new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            services.AddMvc(setup => setup.Filters.Add(new AuthorizeFilter(defaultPolicy)));
        }
        public void Configure(IApplicationBuilder app) {

            app.UseDeveloperExceptionPage();
            app.UseBrowserLink();
            app.UseLogging(new LoggingOptions() { Message = "DylanLog" });
            app.UseStaticFiles();



            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AuthenticationScheme = "Cookies",
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                LoginPath = new PathString("/account/login"),
                AccessDeniedPath = new PathString("/account/denied")
            });

            app.UseMvcWithDefaultRoute();


            app.Run(ctx => ctx.Response.WriteAsync("Hello World!"));
        }
    }
}