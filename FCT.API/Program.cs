using FCT.BL.Extensions;
using FCT.DAC.Extension;
using FCT.DAC.Helpers;
using FluentValidation.AspNetCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

DbConexion.FCT_BG = builder.Configuration.GetConnectionString("FCT_BG")!;
// Add services to the container.
builder.Services.AddInjectionBL();
builder.Services.AddInjectionDAC();

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


