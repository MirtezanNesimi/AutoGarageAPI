namespace AutoGarageAPI.Models;

public class Vehicle
{
    public int Id { get; set; }

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public string PlateNumber { get; set; } = string.Empty;

    public int? UserId { get; set; }

    public User? User { get; set; }
}