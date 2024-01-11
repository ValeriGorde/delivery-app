using System.ComponentModel.DataAnnotations;

namespace Delivery.Web.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Необходимо заполнить поле Город отправителя")]
        public string SendersCity { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Адрес отправителя")]
        public string RecipientCity { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Город получателя")]
        public string SendersAddress { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Адрес получателя")]
        public string RecipientAddress { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Вес груза")]
        [Range(0, int.MaxValue, ErrorMessage ="Вес груза не может быть отрицательным")]
        public int? CargoWeight { get; set; }

        [Required(ErrorMessage = "Необходимо заполнить поле Дата забора груза")]
        public DateOnly? DatePickup { get; set; }
    }
}
