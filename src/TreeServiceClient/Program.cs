using TreeServiceClient.HttpClients.Implementations;
using TreeServiceClient.HttpClients.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IFoldersApiHttpClient, FoldersApiHttpClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["FoldersApiUrl"]!);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Folders}/{action=Index}/{id?}");

app.Run();
