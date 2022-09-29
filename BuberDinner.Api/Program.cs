using BubberDinner.Application;
using BuberDinner.Api.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(opt => opt.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

// Dependency injection
builder.Services
    .AddApplication()
    .AddAInfrastructure(builder.Configuration);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Buber Dinner API",
        Description = "An ASP.NET Core Web API where I learned more about Clean Architecture," +
        " CQRS, interesting design patterns and code",
        Contact = new OpenApiContact
        {
            Name = "Andrei Costache",
            Url = new Uri("https://www.linkedin.com/in/stelian-andrei-costache/")
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.MapControllers();

app.Run();