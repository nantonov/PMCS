using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration ocelotConfiguration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();
IConfiguration appSettingsConfiguration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
var identityServerUrl = appSettingsConfiguration.GetValue<string>("IdentityServerURL");

builder.Services.AddControllers();
builder.Services.AddOcelot(ocelotConfiguration).AddCacheManager(options => options.WithDictionaryHandle());

builder.Services.AddAuthentication()
    .AddJwtBearer("IdentityApiKey", x =>
    {
        x.Authority = identityServerUrl;
        x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidIssuer = identityServerUrl
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddSwaggerForOcelot(ocelotConfiguration);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});

app.UseRouting();

app.UseAuthentication();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("PMCS - Api Gateway.");
    });
});

app.UseOcelot().Wait();

app.Run();
