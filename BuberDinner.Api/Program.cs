using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddAInfrastructure(builder.Configuration);
}

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
{
    
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
}

