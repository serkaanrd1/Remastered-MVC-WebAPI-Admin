using infrastructure.Model;
using RMS.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Entities
{
    public class ServicePerformed : IEntity
    {
        [Key]
        public int ServiceLogID { get; set; }
        public int? TechnicianID { get; set; }
        public int? VehicleID { get; set; }
        public int? ServiceID { get; set; }
        public DateTime? ServiceDate { get; set; }
        public Service? Service { get; set; }

        public bool? IsActive { get; set; }
    }
}
