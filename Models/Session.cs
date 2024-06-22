namespace cinema_backend.Models;

public class Session {
    public int Id { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime EndsAt { get; set; }
    public int MovieId { get; set; }
    public int RoomId { get; set; }
}