using AutoGarageAPI.Models;

namespace AutoGarageAPI.Interfaces;

public interface IVehicleRepository
{
    Task<List<Vehicle>> GetAllAsync();
    Task<Vehicle?> GetByIdAsync(int id);
    Task<Vehicle> CreateAsync(Vehicle vehicle);
    Task<Vehicle?> UpdateAsync(int id, Vehicle vehicle);
    Task<bool> DeleteAsync(int id);
}