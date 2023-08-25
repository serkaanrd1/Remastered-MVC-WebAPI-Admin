using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Order
{
    public class OrderPutDto : IDto
    {
        public int OrderID { get; set; }
        public int? CustomerID { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
