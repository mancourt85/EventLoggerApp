using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data; 
using Domain.Models;
using Infrastructure;

[ApiController]
[Route("api/[controller]")]
public class EventLoggerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public EventLoggerController(IUnitOfWork context)
    {
        _unitOfWork = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventLog>>> GetAllLogs()
    {
        return Ok(await _unitOfWork.EventLogs.GetAllAsync());
    }

    [HttpGet("by-type")]
    public async Task<IActionResult> GetLogsByType([FromQuery] string type)
    {
        var logs = await _unitOfWork.EventLogs.GetByTypeAsync(type);
        return Ok(logs);
    }

    [HttpGet("by-date")]
    public async Task<IActionResult> GetLogsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        var logs = await _unitOfWork.EventLogs.GetByDateRangeAsync(startDate, endDate);
        return Ok(logs);
    }

    [HttpPost]
    public async Task<ActionResult<EventLog>> CreateLog(EventLog log)
    {
        try
        {
            await _unitOfWork.EventLogs.AddAsync(log);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateLog), new { id = log.Id }, log);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Error occurred", detail = ex.Message });
        }
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLog(long id)
    {
        var log = await _unitOfWork.EventLogs.GetByIdAsync(id);
        if (log == null)
            return NotFound();

        _unitOfWork.EventLogs.Delete(log);
        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }
}
