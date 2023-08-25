namespace RemasteredAdminPanel.MvcUI.Areas.AdminPanel.Models.ApiTypes
{
    public class VehicleItem
    {
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public int Mileage { get; set; }
        public string PicturePath { get; set; }

    }
}
