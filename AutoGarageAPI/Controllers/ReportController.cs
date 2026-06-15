using AutoGarageAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGarageAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly GarageReportService _service;

    public ReportController(GarageReportService service)
    {
        _service = service;
    }

    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        var result = await _service.GetDashboardReport();
        return Ok(result);
    }
}