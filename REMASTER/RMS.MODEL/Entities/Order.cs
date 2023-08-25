

using infrastructure.Model;

namespace RMS.Model.Entities
{
    public class Order : IEntity
    {
        public int OrderID { get; set; }
        public int? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalAmount { get; set; }
        public Customer? Customer { get; set; }

        public bool? IsActive { get; set; }
    }
}
