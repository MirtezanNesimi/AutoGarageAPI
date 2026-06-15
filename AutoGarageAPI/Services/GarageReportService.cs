using AutoGarageAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoGarageAPI.Services;

public class GarageReportService
{
    private readonly GarageDbContext _context;

    public GarageReportService(GarageDbContext context)
    {
        _context = context;
    }

    public async Task<object> GetDashboardReport()
    {
        var totalVehicles = await _context.Vehicles.CountAsync();
        var totalAppointments = await _context.Appointments.CountAsync();
        var pendingAppointments = await _context.Appointments.CountAsync(a => a.Status == "Pending");
        var completedAppointments = await _context.Appointments.CountAsync(a => a.Status == "Completed");

        return new
        {
            TotalVehicles = totalVehicles,
            TotalAppointments = totalAppointments,
            PendingAppointments = pendingAppointments,
            CompletedAppointments = completedAppointments
        };
    }
}