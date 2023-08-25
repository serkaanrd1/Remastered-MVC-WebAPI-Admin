namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class ServicePerformedItem
    {
        public int ServiceLogID { get; set; }
        public int? TechnicianID { get; set; }
        public int? VehicleID { get; set; }
        public int? ServiceID { get; set; }

    }
}
