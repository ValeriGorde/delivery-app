namespace Delivery.Web.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string SendersCity { get; set; }
        public string RecipientCity { get; set; }
        public string SendersAddress { get; set; }
        public string RecipientAddress { get; set; }
        public int CargoWeight { get; set; }
        public DateOnly DatePickup { get; set; }
    }
}
