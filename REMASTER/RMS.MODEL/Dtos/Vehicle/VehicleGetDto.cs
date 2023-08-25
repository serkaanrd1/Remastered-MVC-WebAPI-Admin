using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Vehicle
{
    public class VehicleGetDto : IDto
    {
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public string? LicensePlate { get; set; }
        public int? Mileage { get; set; }
        public string? PicturePath { get; set; }

        public bool? IsActive { get; set; }
    }
}
