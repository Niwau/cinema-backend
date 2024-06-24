using Microsoft.AspNetCore.Mvc;
using cinema_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cinema_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController(AppDbContext db) : ControllerBase
{

    [HttpGet()]
    public async Task<IActionResult> Get()
    {
        try {
            List<Session> sessions = await db.Sessions.ToListAsync();

            if (sessions.Count == 0) {
                return Ok(new List<Session>());
            }

            return Ok(db.Sessions.ToList());
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Session session)
    {
        try {
            await db.Sessions.AddAsync(session);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = session.Id }, session);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}/chairs")]
    public async Task<IActionResult> GetSessionChairs(int id)
    {
        try {
            List<Session> sessions = await db.Sessions.Where(s => s.MovieId == id).ToListAsync();

            if (sessions.Count == 0) {
                return Ok(new List<Session>());
            }

            return Ok(sessions);
        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Session session)
    {
        try {
            var sessionToUpdate = await db.Sessions.FindAsync(id);

            if (sessionToUpdate == null) {
                return NotFound();
            }

            sessionToUpdate.MovieId = session.MovieId;
            sessionToUpdate.RoomId = session.RoomId;
            sessionToUpdate.StartsAt = session.StartsAt;
            sessionToUpdate.EndsAt = session.EndsAt;
        
            await db.SaveChangesAsync();
            return Ok(sessionToUpdate);

        } catch (Exception e) {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try {
            var session = await db.Sessions.FindAsync(id);

            if (session == null) {
                return NotFound();
            }
            
            db.Sessions.Remove(session);
            await db.SaveChangesAsync();

            return Ok(session);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}