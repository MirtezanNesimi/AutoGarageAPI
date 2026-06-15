using AutoGarageAPI.Data;
using AutoGarageAPI.Interfaces;
using AutoGarageAPI.Repositories;
using AutoGarageAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GarageDbContext>(options =>
    options.UseSqlite("Data Source=autogarage.db"));

builder.Services.AddScoped<GarageReportService>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();