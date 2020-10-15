namespace NMC.Models
{
    public class DepartmentRoom
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
