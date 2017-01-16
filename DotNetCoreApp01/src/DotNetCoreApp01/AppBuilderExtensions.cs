using DotNetCoreApp01;

namespace Microsoft.AspNetCore.Builder {
    public static class AppBuilderExtensions {
        public static void UseLogging(this IApplicationBuilder app, LoggingOptions options) {
            app.UseMiddleware<LoggingMiddleware>(options);
        }
    }
}