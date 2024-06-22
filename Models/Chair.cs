namespace cinema_backend.Models
{
    public class Chair {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int RowId { get; set; }
        public int ColumnId { get; set; }
    }
}