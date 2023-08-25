using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Invoice
{
    public class InvoicePutDto : IDto
    {
        public int InvoiceID { get; set; }

        public int? CustomerID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? IsActive { get; set; }
    }
}
