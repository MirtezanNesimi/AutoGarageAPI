namespace AutoGarageAPI.DTOs;

public class AppointmentDto
{
    public DateTime AppointmentDate { get; set; }
    public string ServiceType { get; set; } = string.Empty;
    public int VehicleId { get; set; }
}