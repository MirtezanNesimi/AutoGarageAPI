namespace AutoGarageAPI.Models;

public class Appointment
{
    public int Id { get; set; }

    public DateTime AppointmentDate { get; set; }

    public string ServiceType { get; set; } = string.Empty;

    public string Status { get; set; } = "Pending";

    public int VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }
}