using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using api.Services;
using Microsoft.Extensions.Logging;
using Serilog;
using api.Middleware;

namespace api
{
    public class Startup
    {
        //public IConfiguration Configuration { get; }
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.Configure<AppSettings>(Configuration);

            //one instances of the service for the entire application, so every method, and every component will have the same object injected
            services.AddSingleton<IGreeter, Greeter>();

            //one instance of the service for each http request
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();

            services.AddSingleton<Serilog.ILogger>(new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/error");
                app.UseExceptionHandler(new ExceptionHandlerOptions
                {
                    //ExceptionHandlingPath = "/error"
                    ExceptionHandler = context => context.Response.WriteAsync("Opps!")
                });
            }

            app.UseSerilogCustomEnricher();

            //both UseDefaultFiles and UseStaticFiles
            app.UseFileServer();
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            //app.UseWelcomePage(new WelcomePageOptions {
            //    Path = "/welcome"
            //});

            //app.Run(async (context) =>
            //{
            //    var message = greeter.GetGreeting();
            //    await context.Response.WriteAsync(message);
            //});

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(ConfigureRoutes);

            app.Run(ctx => ctx.Response.WriteAsync("Not found"));
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
