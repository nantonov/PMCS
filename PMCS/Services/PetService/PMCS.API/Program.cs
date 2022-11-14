using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using PMCS.API.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PMCS.API.Constants.Authorization;
using PMCS.API.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.RegisterAuthorizationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.AddSecurityConfiguration());
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.RegisterBusinessLogicDependencies(configuration);

var app = builder.Build();

var supportedCultures = new[]
{
    new CultureInfo("en")
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(supportedCultures[0]),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("DefaultPolicy");

app.MapControllers();

app.Run();

public partial class Program { }
