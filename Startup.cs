using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Octokit;

namespace HelloMvc
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(source =>
                {
                    source.Path = "appsettings.json";
                    source.ReloadOnChange = true;
                })
                .AddJsonFile(source =>
                {
                    source.Path = $"appsettings.{env.EnvironmentName}.json";
                    source.ReloadOnChange = true;
                    source.Optional = true;
                })
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<GitHubClient, GitHubClient>(_ =>
                new GitHubClient(new ProductHeaderValue("SquashNext"))
                {
                    Credentials = new Credentials(Configuration["Octokit:AuthToken"]),
                });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}