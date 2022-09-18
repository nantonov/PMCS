using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("ocelot.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOcelot(configuration).AddCacheManager(options => options.WithDictionaryHandle());

builder.Services.AddAuthentication()
    .AddJwtBearer("IdentityApiKey", x =>
    {
        x.Authority = "https://localhost:5001";
        x.RequireHttpsMetadata = false;
        x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            ValidateAudience = false,
            ValidateIssuer = true,
            ValidIssuer = "https://localhost:5001"
        };
    });

builder.Services.AddSwaggerForOcelot(configuration);

var app = builder.Build();

app.UseSwaggerForOcelotUI(opt =>
{
    opt.PathToSwaggerGenerator = "/swagger/docs";
});
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("PMCS - Api Gateway.");
    });
});

app.UseOcelot().Wait();

app.Run();
