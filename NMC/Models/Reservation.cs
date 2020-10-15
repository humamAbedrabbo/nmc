using System;
using System.Collections.Generic;

namespace NMC.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string RoomNo { get; set; }
        public Room Room { get; set; }
        public int? GradeId { get; set; }
        public RoomGrade Grade { get; set; }
        public string BedNo { get; set; }
        public int ReservedBeds { get; set; }
        public DateTime FromDate { get; set; }
        public string StartTime { get; set; }
        public DateTime ToDate { get; set; }
        public string EndTime { get; set; }
        public string Requestor { get; set; }
        public DateTime RequestDate { get; set; }
        public int? PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Message { get; set; }
        public int? AdmissionId { get; set; }
        public Admission Admission { get; set; }
        public bool Active { get; set; }
        public ICollection<ReservationStatus> Status { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }

    }
}
