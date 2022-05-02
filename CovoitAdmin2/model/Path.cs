using System;
using System.Collections.Generic;

#nullable disable

namespace CovoitAdmin2.Model
{
    public partial class Path
    {
        public int IdPath { get; set; }
        public int IdTrip { get; set; }
        public TimeSpan DepartureTime { get; set; }
    }
}
