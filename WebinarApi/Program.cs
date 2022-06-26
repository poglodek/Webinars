using WebinarApi;
using Webinars.CQRS;
using Webinars.Dapper.SQLServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCQRS();
builder.Services.AddRepository();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterEndpoints();

app.Run();