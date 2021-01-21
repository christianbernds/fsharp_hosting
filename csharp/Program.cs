namespace CSharp.WebApi
{
    using AtlasEngine;
    using AtlasEngine.ApiClient;

    using CSharp.WebApi.ExternalTaskHandler;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseExternalTaskWorkers(opt => opt.ActivateHandlersInScopes = true)
                .ConfigureServices((context, services) =>
                {
                    services.Configure<ApiClientSettings>(context.Configuration.GetSection("ExternalTaskWorker"));

                    services.AddScoped<AddHandler>();
                })
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
    }
}
