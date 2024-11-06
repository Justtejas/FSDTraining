using System;
using System.Collections.Generic;

namespace DBFAAPI.Models
{
    public partial class Booking
    {
        public int Bookingid { get; set; }
        public int Roomid { get; set; }
        public string Customername { get; set; } = null!;
        public DateTime Checkindate { get; set; }
        public DateTime Checkoutdate { get; set; }

        public virtual Room Room { get; set; } = null!;
    }
}
