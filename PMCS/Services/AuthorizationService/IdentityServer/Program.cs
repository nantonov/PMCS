using AutoMapper;
using IdentityServer.Data;
using IdentityServer.Data.Initializaton;
using IdentityServer.Models;
using IdentityServer.Profiles;
using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddEndpointsApiExplorer();

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;
var connectionString = configuration.GetConnectionString("AuthDbConnection");

var mapperConfiguration = new MapperConfiguration(c =>
{
    c.AddProfile<ViewModelUser>();
});
builder.Services.AddSingleton<IMapper>(s => mapperConfiguration.CreateMapper());

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString,
        b => b.MigrationsAssembly(migrationsAssembly))).
    AddIdentity<User, Role>(config =>
    {
        config.Password.RequireDigit = false;
        config.Password.RequireLowercase = false;
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireUppercase = false;
        config.Password.RequiredLength = 6;
    }).
    AddEntityFrameworkStores<AuthDbContext>();

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

builder.Services.AddCors(config =>
{
    config.AddPolicy("DefaultPolicy",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


builder.Services.AddAuthentication()
    .AddOAuth("VK", "VKontakte", options =>
    {
        options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
        options.ClientId = builder.Configuration["Authentication:VK:ClientId"];
        options.ClientSecret = builder.Configuration["Authentication:VK:ClientSecret"];
        options.ClaimsIssuer = "VK Provider";
        options.SaveTokens = true;
        options.CallbackPath = new PathString("/signin-vkontakte-token");
        options.AuthorizationEndpoint = "https://oauth.vk.com/authorize";
        options.TokenEndpoint = "https://oauth.vk.com/access_token";
        options.Scope.Add("email");
        options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user_id");
        options.ClaimActions.MapJsonKey(ClaimTypes.Email, "email");

        options.Events = new OAuthEvents
        {
            OnCreatingTicket = context =>
            {
                context.RunClaimActions(context.TokenResponse.Response.RootElement);
                return Task.CompletedTask;
            },
            OnRemoteFailure = OnFailure
        };
    });

Task OnFailure(RemoteFailureContext arg)
{
    Console.WriteLine(arg);
    return Task.CompletedTask;
}

var app = builder.Build();

DataInitializer.InitializeDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();
app.UseCors("DefaultPolicy");
app.UseHttpsRedirection();
app.UseIdentityServer();
app.UseAuthorization();

app.UseCsp(options => options.DefaultSources(s => s.Self())
    .ConnectSources(s => s.CustomSources("wss://localhost:44348/IdentityServer/")));

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
