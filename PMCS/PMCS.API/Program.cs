using System.Globalization;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Localization;
using PMCS.API.Middlewares;
using PMCS.DAL.DI;
using PMCS.DLL.DI;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddFluentValidation(fv=>fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

DataAccessRegistration.RegisterDataAccessDependencies(builder.Services, configuration);
BusinessLogicRegistration.RegisterBusinessLogicDependencies(builder.Services);

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
