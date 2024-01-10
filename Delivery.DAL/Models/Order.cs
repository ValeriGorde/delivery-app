using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.DAL.Models
{
    /// <summary>
    /// Класс-модель для заказа
    /// </summary>
    public class Order: BaseModel
    {
        public string SendersCity { get; set; }
        public string RecipientCity { get; set; }
        public string SendersAddress { get; set; }
        public string RecipientAddress { get; set;}
        public int CargoWeight { get; set; }
        public DateOnly DatePickup { get; set; }
    }
}
