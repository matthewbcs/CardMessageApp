using Autofac.Extensions.DependencyInjection;
using CardMessageApp.Model;
using CardMessageApp.Service.Card;
using CardMessageApp.Service.ChatGpt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddSingleton<IChatGPTService, ChatGPTService>();
builder.Services.AddSingleton<IAppSettingsService, AppSettingsService>();
builder.Services.AddSingleton<ICardService, CardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
