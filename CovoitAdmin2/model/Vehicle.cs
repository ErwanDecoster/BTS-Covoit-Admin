using System;
using System.Collections.Generic;

#nullable disable

namespace CovoitAdmin2.Model
{
    public partial class Vehicle
    {
        public int IdVehicles { get; set; }
        public int IdMotorization { get; set; }
        public int IdUser { get; set; }
        public string VehicleName { get; set; }
        public int NbPlaces { get; set; }
        public string Color { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateModification { get; set; }
    }
}
