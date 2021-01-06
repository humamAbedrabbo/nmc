using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace NMC.Models
{
    [Index(nameof(Floor), nameof(RoomNo), IsUnique = true)]
    public class Room
    {
        public int Id { get; set; }

        [Display(Name = "Unit")]
        public int UnitId { get; set; }

        public int Floor { get; set; }

        [Required, StringLength(5, MinimumLength = 1)]
        [Display(Name = "Room No.")]
        public string RoomNo { get; set; }

        [Display(Name = "Room")]
        public string Name => $"{Floor}/{RoomNo}";

        public int Capacity { get; set; } = 1;

        [Display(Name = "Inpatient")]
        public int? CurrentInpatientId { get; set; }

        public Unit Unit { get; set; }
        public Inpatient CurrentInpatient { get; set; }

        public List<Timeslot> Slots { get; set; } = new();

        public RoomStatus GetStatus(DateTime? start = null, DateTime? end = null)
        {
            if (!start.HasValue) start = DateTime.Now;
            if (!end.HasValue) end = start.Value.AddHours(23).AddMinutes(59);

            if (CurrentInpatientId.HasValue)
            {
                var overlap2 = (end <= CurrentInpatient.EstDischargeDate && end >= CurrentInpatient.AdmissionDate)
                    || (start >= CurrentInpatient.AdmissionDate && start <= CurrentInpatient.EstDischargeDate)
                    || (start <= CurrentInpatient.AdmissionDate && end >= CurrentInpatient.EstDischargeDate);
                if(overlap2) return RoomStatus.Reserved; 
            }

            if (IsAvailable(start.Value, end.Value))
                return RoomStatus.Available;
            else
                return RoomStatus.Booked;
        }

        public string GetStatusCss(DateTime? start = null, DateTime? end = null)
        {
            var status = GetStatus(start, end);
            switch(status)
            {
                case RoomStatus.Reserved:
                    return "status-red";
                case RoomStatus.Booked:
                    return "status-blue";
                default:
                    return "status-green";
            }
        }

        public bool IsAvailable(DateTime start, DateTime end)
        {
            var overlaps = Slots.Where
                (slot =>
                    (end <= slot.End && end >= slot.Start) ||
                    (start >= slot.Start && start <= slot.End) ||
                    (start <= slot.Start && end >= slot.End)
                ).Count();
            bool result = (overlaps == 0);

            // Check Reservation
            if(CurrentInpatientId.HasValue)
            {
                var overlap2 = (end <= CurrentInpatient.EstDischargeDate && end >= CurrentInpatient.AdmissionDate)
                    || (start >= CurrentInpatient.AdmissionDate && start <= CurrentInpatient.EstDischargeDate)
                    || (start <= CurrentInpatient.AdmissionDate && end >= CurrentInpatient.EstDischargeDate);
                result &= !overlap2;
            }

            return result;
        }

        public bool BookSlot(Booking booking, DateTime start, DateTime end)
        {
            //if (start < DateTime.Now) return false;
            if (end <= start) return false;
            if ((end - start).TotalHours < 12) return false;
            if(start.Hour < 12)
            {
                start = start.Date;
            }
            else
            {
                start = start.Date.AddHours(23).AddMinutes(59);
            }
            if(end.Hour < 12)
            {
                end = end.Date;
            }
            else
            {
                end = end.Date.AddHours(23).AddMinutes(59);
            }

            if (!IsAvailable(start, end)) return false;

            Timeslot slot = new Timeslot(this, booking, start, end - start);
            Slots.Add(slot);
            booking.Slots.Add(slot);
            return true;
        }
        
        
        public List<SlotSegment> GetDayStatus(DateTime date)
        {
            List<SlotSegment> segments = new();
            DateTime start = date.Date;
            DateTime end = start.AddHours(23).AddMinutes(59);
            // DateTime end = start.AddDays(1);

            if(IsAvailable(start, end))
            {
                segments.Add(new SlotSegment { Start = start, End = end, Status = RoomStatus.Available });
                return segments;
            }

            if(CurrentInpatientId.HasValue)
            {
                if(date >= CurrentInpatient.AdmissionDate || date <= CurrentInpatient.EstDischargeDate)
                {
                    segments.Add(new SlotSegment { Start = start, End = end, Status = RoomStatus.Reserved });
                    return segments;
                }
            }
            else
            {
                segments.Add(new SlotSegment { Start = start, End = end, Status = RoomStatus.Booked });
                return segments;

            }

            var daySlots = Slots.Where(slot =>
                (end <= slot.End && end >= slot.Start) ||
                (start >= slot.Start && start <= slot.End) ||
                (start <= slot.Start && end >= slot.End)
                ).OrderBy(x => x.Start);

            if (daySlots.Count() == 0)
            {
                segments.Add(new SlotSegment { Start = start, End = end, Status = RoomStatus.Available });
                return segments;
            }

            SlotSegment seg = new();
            seg.Start = start;
            foreach (var slot in daySlots)
            {

                if (slot.Start > start)
                {
                    seg.End = slot.Start;
                    seg.Status = RoomStatus.Available;
                    segments.Add(seg);
                    start = slot.Start;
                    seg = new SlotSegment { Start = start };
                }

                if (slot.End < end)
                {
                    seg.End = slot.End;
                    seg.Status = RoomStatus.Booked;
                    segments.Add(seg);
                    start = slot.End;
                    seg = new SlotSegment { Start = start };
                }
                else if(slot.End == end)
                {
                    seg.End = slot.End;
                    seg.Status = RoomStatus.Booked;
                    segments.Add(seg);
                    start = slot.End;

                }
                else
                {
                    seg.End = end;
                    seg.Status = RoomStatus.Booked;
                    segments.Add(seg);
                    seg = null;
                }
            }

            if (seg != null)
            {
                seg.End = end;
                seg.Status = RoomStatus.Available;
                segments.Add(seg);
                seg = null;
            }

            segments.RemoveAll(x => (x.End - x.Start).TotalHours < 1);
            return segments;
        }
    }
}
