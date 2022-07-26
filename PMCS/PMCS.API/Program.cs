using PMCS.API.Extentions;
using PMCS.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExceptionMiddleware();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
