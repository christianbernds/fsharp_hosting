namespace FSharp.WebApi

open AtlasEngine
open AtlasEngine.ApiClient
open FSharp.WebApi.ExternalTaskHandler
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting

module Program =
    let exitCode = 0

    let CreateHostBuilder args =
        Host.CreateDefaultBuilder(args)
            .UseExternalTaskWorkers(fun options -> options.ActivateHandlersInScopes = true |> ignore)
            .ConfigureServices(fun context services ->
                services.Configure<ApiClientSettings>(context.Configuration.GetSection("ExternalTaskWorker")) |> ignore
                services.AddScoped<AddHandler>() |> ignore)
            .ConfigureWebHostDefaults(fun webBuilder ->
                webBuilder.UseStartup<Startup>() |> ignore
            )

    [<EntryPoint>]
    let main args =
        CreateHostBuilder(args).Build().Run()

        exitCode
