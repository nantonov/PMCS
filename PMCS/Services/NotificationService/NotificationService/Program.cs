using Microsoft.AspNetCore.Http.Connections;
using Notifications.BLL.DI;
using Notifications.BLL.Resources.Constants;
using Notifications.BLL.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
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
app.UseAuthorization();

app.MapControllers();

app.MapHub<NotificationHub>(HubConfiguration.HubURL, options =>
{
    options.Transports = HttpTransportType.ServerSentEvents;
});

app.Run();
