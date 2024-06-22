using Microsoft.AspNetCore.Mvc;
using cinema_backend.Models;

namespace cinema_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly List<Session> sessions =
    [
        new() { Id = 1, StartsAt = new DateTime(2022, 1, 1, 10, 0, 0), EndsAt = new DateTime(2022, 1, 1, 12, 0, 0), MovieId = 1, RoomId = 1 },
    ];

    [HttpGet()]
    public IActionResult Get()
    {
        return Ok(sessions);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Session session)
    {
        sessions.Add(session);
        return CreatedAtAction(nameof(Get), new { id = session.Id }, session);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Session session)
    {
        var index = sessions.FindIndex(movie => movie.Id == id);
        
        if (index == -1) {
          return NotFound();
        }

        sessions[index] = session;
        
        return Ok(sessions[index]);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var session = sessions.Find(session => session.Id == id);

        if (session == null) {
          return NotFound();
        }
          
        sessions.Remove(session);
        return Ok(session);
    }

}