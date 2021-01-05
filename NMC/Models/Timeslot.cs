using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMC.Models
{
    public class Timeslot
    {
        public Timeslot()
        {

        }

        public Timeslot(Room r, Booking b, DateTime date, TimeSpan dur)
        {
            Room = r;
            Booking = b;
            Start = date;
            Duration = dur;
        }

        public int Id { get; set; }

        [Display(Name = "Room")]
        public int RoomId { get; set; }

        [Display(Name = "Booking")]
        public int BookingId { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime End => Start + Duration;

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate => Start.Date;

        [Display(Name = "Start Time")]
        public string StartTime => Start.ToString("HH:mm tt");

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate => End.Date;

        [Display(Name = "End Time")]
        public string EndTime => End.ToString("HH:mm tt");

        public Room Room { get; set; }
        public Booking Booking { get; set; }
    }
}
