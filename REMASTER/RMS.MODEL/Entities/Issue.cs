using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Entities
{
    public class Issue : IEntity
    {
        public int IssueID { get; set; }
        public int? CustomerID { get; set; }
        public int? VehicleID { get; set; }
        public string? Description { get; set; }
        public Customer? Customer { get; set; }

        public bool? IsActive { get; set; }
    }
}
