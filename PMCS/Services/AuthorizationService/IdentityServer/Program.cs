using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder().Build();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
//var connectionString = configuration.GetConnectionString("AuthDbConnection");
var connectionString = "Server=localhost;Database=Identity;Trusted_Connection=True";

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly(migrationsAssembly)));
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<User>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationsAssembly));
    })
    .AddDeveloperSigningCredential();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.Cookie.Name = "PMCS.Identity.Cookie";
    config.LoginPath = "/Account/Login";
    config.LogoutPath = "/Account/Logout";
});

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseIdentityServer();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
