using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Vehicle
{
    public class VehiclePostDto : IDto
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
       
    }
}
