using FluentValidation.AspNetCore;
using Notifications.BLL.DI;
using System.Reflection;
using Notifications.API.Middlewares;
using Notifications.BLL.DI;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Http.Connections;
using Notifications.BLL.DI;
using Notifications.BLL.Resources.Constants;
using Notifications.BLL.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().Build();

Log.Logger = Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .Enrich.WithThreadId()
    .Enrich.WithThreadName()
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) ({ThreadName}) {Message}{NewLine}{Exception}")
    .CreateLogger();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())); ;
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});

BusinessLogicRegistration.RegisterBusinessLogicDependencies(builder.Services);

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>(HubConfiguration.HubURL, options =>
{
    options.Transports = HttpTransportType.ServerSentEvents;
});

app.Run();
