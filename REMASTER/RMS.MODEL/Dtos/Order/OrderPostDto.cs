using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.Model.Dtos.Order
{
    public class OrderPostDto : IDto
    {
        public int? CustomerID { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
