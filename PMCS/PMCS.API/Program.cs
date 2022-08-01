using System.Reflection;
using FluentValidation.AspNetCore;
using PMCS.API.Middlewares;
using PMCS.DAL.DI;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DataAccessRegistration.RegisterDataAccessDependencies(builder.Services, configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
