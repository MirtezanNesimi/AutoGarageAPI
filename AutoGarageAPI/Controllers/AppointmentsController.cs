using AutoGarageAPI.Data;
using AutoGarageAPI.DTOs;
using AutoGarageAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoGarageAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly GarageDbContext _context;

    public AppointmentsController(GarageDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Appointments.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Create(AppointmentDto dto)
    {
        var appointment = new Appointment
        {
            AppointmentDate = dto.AppointmentDate,
            ServiceType = dto.ServiceType,
            VehicleId = dto.VehicleId,
            Status = "Pending"
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        return Ok(appointment);
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment == null)
            return NotFound();

        appointment.Status = "Completed";

        await _context.SaveChangesAsync();

        return Ok(appointment);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment == null)
            return NotFound();

        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();

        return Ok("Appointment deleted");
    }
}