using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Payment
{
    public class PaymentPostDto : IDto
    {
        public int? CustomerID { get; set; }
        public int? InvoiceID { get; set; }

        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }

        public bool? IsActive { get; set; }
    }
}
