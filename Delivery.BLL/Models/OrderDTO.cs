using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.BLL.Models
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string SendersCity { get; set; }
        public string RecipientCity { get; set; }
        public string SendersAddress { get; set; }
        public string RecipientAddress { get; set; }
        public int CargoWeight { get; set; }
        public DateTime DatePickup { get; set; }
    }
}
