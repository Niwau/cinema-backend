using Microsoft.AspNetCore.Mvc;
using cinema_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class TicketController(AppDbContext db) : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        try {
            List<Ticket> tickets = await db.Tickets.ToListAsync();

            if (tickets.Count == 0) {
                return Ok(new List<Ticket>());
            }

            return Ok(db.Tickets.ToList());
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Ticket ticket)
    {
        try {
            await db.Tickets.AddAsync(ticket);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ticket.Id }, ticket);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }
}