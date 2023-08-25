namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.Dtos.Payment
{
    public class NewPaymentDto
    {
        public int CustomerID { get; set; }
        public int InvoiceID { get; set; }

        public decimal Amount { get; set; }

    }
}
