using TreeService.Extensions;

var webApplication = WebApplication
    .CreateBuilder(args)
    .ConfigureDIContainer()
    .Build();

webApplication.ConfigureMiddlewares();

await webApplication.RunAsync();