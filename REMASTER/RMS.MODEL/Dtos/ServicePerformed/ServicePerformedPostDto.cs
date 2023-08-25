using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.ServicePerformed
{
    public class ServicePerformedPostDto : IDto
    {
        public int? TechnicianID { get; set; }
        public int? VehicleID { get; set; }
        public int? ServiceID { get; set; }
        public DateTime? ServiceDate { get; set; }

        public bool? IsActive { get; set; }
    }
}
