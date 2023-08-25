using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using RMS.Business.Extensions;
using RMS.WebAPI.Extensions;
using WS.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAPIServices();
builder.Services.AddBusinessServices();
// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
app.UseCustomException();

app.Run();
