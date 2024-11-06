using System;
using System.Collections.Generic;

namespace DBFAAPI.Models
{
    public partial class Room
    {
        public Room()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Roomid { get; set; }
        public string Roomtype { get; set; } = null!;
        public string Availability { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
