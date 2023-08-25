namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class PaymentItem
    {
        public int PaymentID { get; set; }
        public int CustomerID { get; set; }
        public int InvoiceID { get; set; }
        public decimal Amount { get; set; }

    }
}
