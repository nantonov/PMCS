using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Schedule.API.Constants;
using Schedule.API.Middlewares;
using Schedule.Application.Common.CommandHandlers;
using Schedule.Application.Configuration;
using Schedule.Application.DI;
using Schedule.BackgroundTasks.DI;
using Schedule.BackgroundTasks.EventHandlers;
using Schedule.Infrastructure.DI;
using Serilog;
using Serilog.Events;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

Log.Logger = Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddMediatR(typeof(AddReminderCommandHandler).Assembly, typeof(ReminderTriggeredDomainEventHandler).Assembly);

builder.Services.RegisterDependencies(configuration);
builder.Services.RegisterDependencies();
builder.Services.AddBackgroundTasks();

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

Schedule.API.Extentions.ServiceCollectionExtensions.ConfigureAuthenticationScheme(builder.Services);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyBasedAuthorizationParameters.AllMethodsAllowedPolicy,
        policy => policy.RequireScope(PolicyBasedAuthorizationParameters.AllMethodsAllowedScopeRequired));
});

builder.Services.AddSwaggerGen(Schedule.API.Extentions.SwaggerGenOptionsExtensions.AddSecurityConfiguration);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId(AuthConfiguration.SwaggerClientId);
        options.OAuthScopeSeparator(" ");
        options.OAuthClientSecret(AuthConfiguration.ClientSecret);
        options.DocExpansion(DocExpansion.List);
    });
}

app.UseHttpsRedirection();

app.UseCors("DefaultPolicy");

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
