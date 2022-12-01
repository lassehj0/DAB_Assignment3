using Assignment2.Models;
using Assignment2.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json.Serialization;
using MongoDB;
using MongoDB.Bson.Serialization;
using Assignment2.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<mongoDBSettings>(
	builder.Configuration.GetSection("mongoDB"));

builder.Services.AddSingleton<FacilitiesService>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

BsonClassMap.RegisterClassMap<FFF>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();