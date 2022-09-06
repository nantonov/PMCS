using FluentValidation.AspNetCore;
using Schedule.API.Middlewares;
using Schedule.Application.DI;
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

InfrastructureDependencies.RegisterDependencies(builder.Services, configuration);
ApplicationDependencies.RegisterDependencies(builder.Services);

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

Schedule.API.Extentions.ServiceCollectionExtensions.ConfigureAuthenticationScheme(builder.Services);
builder.Services.AddAuthorization();

builder.Services.AddSwaggerGen(options =>
{
    Schedule.API.Extentions.SwaggerGenOptionsExtensions.AddSecurityConfiguration(options);
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId("swagger-client-id");
        options.OAuthScopeSeparator(" ");
        options.OAuthClientSecret("client_secret");
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
