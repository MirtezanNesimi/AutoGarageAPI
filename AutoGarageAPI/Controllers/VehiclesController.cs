using AutoGarageAPI.Data;
using AutoGarageAPI.DTOs;
using AutoGarageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoGarageAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly GarageDbContext _context;

    public VehiclesController(GarageDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Vehicles.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(VehicleDto dto)
    {
        var vehicle = new Vehicle
        {
            Brand = dto.Brand,
            Model = dto.Model,
            PlateNumber = dto.PlateNumber,
            UserId = dto.UserId
        };

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return Ok(vehicle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, VehicleDto dto)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
            return NotFound();

        vehicle.Brand = dto.Brand;
        vehicle.Model = dto.Model;
        vehicle.PlateNumber = dto.PlateNumber;
        vehicle.UserId = dto.UserId;

        await _context.SaveChangesAsync();

        return Ok(vehicle);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
            return NotFound();

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return Ok("Vehicle deleted successfully");
    }
}