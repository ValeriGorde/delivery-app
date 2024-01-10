using Delivery.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.BLL.Contracts.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrder(Guid id);
        Task CreateOrder(OrderDTO orderDto);
        Task DeleteOrderById(Guid id);
        Task UpdateOrder(OrderDTO orderDto);


    }
}
