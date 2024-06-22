namespace cinema_backend.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public required string CustomerEmail { get; set; }
        public int SessionId { get; set; }
        public int ChairId { get; set; }
    }
}