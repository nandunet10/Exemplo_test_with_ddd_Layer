using TestExecutionAec.Application.Commands;
using TestExecutionAec.OfflineProcessor;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient();

        //services.AddTransient<IProcessarDadosAecCommandHandler, ProcessarDadosAecCommandHandler>();

        services.Configure<DadosBase>(hostContext.Configuration.GetSection("DadosBase"));

        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
