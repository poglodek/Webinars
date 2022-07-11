using WebinarApi;
using Webinars.CQRS;
using Webinars.Dapper.MySQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCQRS();
builder.Services.AddRepository();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<Middleware>();

builder.Services.AddServiceBus();



var app = builder.Build();
app.UseMiddleware<Middleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.Run();

public partial class Program
{
    //For tests
}

