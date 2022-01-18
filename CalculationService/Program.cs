using CalculationService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<QueuedHostedService>();
        services.AddSingleton<IBackgroundTaskQueue>(_ =>
        {
            var queueCapacity = 100;

            return new DefaultBackgroundTaskQueue(queueCapacity);
        });
    })
    .Build();

await host.RunAsync();
