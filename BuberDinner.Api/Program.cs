using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddPresentation()
    .AddApplication()
    .AddAInfrastructure(builder.Configuration);
}

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

