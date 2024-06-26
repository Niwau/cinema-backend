namespace cinema_backend.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public int SessionId { get; set; }
        public int ChairId { get; set; }
        public decimal Value { get; set; }
    }

    public class TicketResponse
    {
        public int Id { get; set; }
        public string CustomerEmail { get; set; }
        public int SessionId { get; set; }
        public int ChairId { get; set; }
        public decimal Value { get; set; }

        public TicketResponse(Ticket ticket)
        {
            Id = ticket.Id;
            CustomerEmail = ticket.CustomerEmail;
            SessionId = ticket.SessionId;
            ChairId = ticket.ChairId;
            Value = ticket.Value;
        }
    }
}