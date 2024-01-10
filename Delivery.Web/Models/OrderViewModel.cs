namespace Delivery.Web.Models
{
    public class OrderViewModel
    {
        public string SendersCity { get; set; }
        public string RecipientCity { get; set; }
        public string SendersAddress { get; set; }
        public string RecipientAddress { get; set; }
        public int CargoWeigth { get; set; }
        public DateTime DatePickup { get; set; }
    }
}
