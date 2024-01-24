using Microsoft.Extensions.Logging.Configuration;
using Serilog;

//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json").Build();

//Log.Logger = new LoggerConfiguration()
//    .ReadFrom
//    .Configuration(configuration)
//    .CreateLogger();


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSerilogRequestLogging();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
