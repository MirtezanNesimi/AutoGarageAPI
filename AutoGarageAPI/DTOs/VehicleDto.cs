namespace AutoGarageAPI.DTOs;

public class VehicleDto
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string PlateNumber { get; set; } = string.Empty;
    public int UserId { get; set; }
}