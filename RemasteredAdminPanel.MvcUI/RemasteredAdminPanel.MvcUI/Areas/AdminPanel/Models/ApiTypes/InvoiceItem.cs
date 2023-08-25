namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class InvoiceItem
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
