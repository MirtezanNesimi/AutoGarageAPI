using AutoGarageAPI.Data;
using AutoGarageAPI.Interfaces;
using AutoGarageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoGarageAPI.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly GarageDbContext _context;

    public VehicleRepository(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<List<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task<Vehicle?> GetByIdAsync(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<Vehicle> CreateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle?> UpdateAsync(int id, Vehicle updatedVehicle)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
            return null;

        vehicle.Brand = updatedVehicle.Brand;
        vehicle.Model = updatedVehicle.Model;
        vehicle.PlateNumber = updatedVehicle.PlateNumber;
        vehicle.UserId = updatedVehicle.UserId;

        await _context.SaveChangesAsync();

        return vehicle;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null)
            return false;

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return true;
    }
}