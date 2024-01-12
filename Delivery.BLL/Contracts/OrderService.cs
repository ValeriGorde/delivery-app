using AutoMapper;
using Delivery.BLL.Contracts.Interfaces;
using Delivery.BLL.Models;
using Delivery.DAL.Models;
using Delivery.DAL.Repositories.Base;

namespace Delivery.BLL.Contracts
{
    /// <summary>
    /// Сервис по обработке crud методов для контроллера Order
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }

        public async Task CreateOrder(OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            await _orderRepo.Add(order);
        }

        public async Task DeleteOrderById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Не установлено id заказа");

            var order = await _orderRepo.GetById(id);
            if (order == null)
                throw new InvalidOperationException("Данный заказ не найден");

            await _orderRepo.Delete(order);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllOrders()
        {
            var orders = await _orderRepo.GetAll();
            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("Не установлено id заказа");

            var order = await _orderRepo.GetById(id);
            if (order == null)
                throw new InvalidOperationException("Заказ не найден");

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task UpdateOrder(OrderDTO orderDto)
        {
            if (orderDto == null)
                throw new ArgumentNullException("Не установлен заказ");

            var orderDB = await _orderRepo.GetById(orderDto.Id);
            if (orderDB == null)
                throw new InvalidOperationException("Данный заказ не найден");

            var order = _mapper.Map<Order>(orderDto);

            orderDB.SendersCity = order.SendersCity;
            orderDB.SendersAddress = order.SendersAddress;
            orderDB.RecipientCity = orderDto.RecipientCity; ;
            orderDB.RecipientAddress = orderDto.RecipientAddress;
            orderDB.CargoWeight = orderDto.CargoWeight;
            orderDB.DatePickup = orderDto.DatePickup;

            await _orderRepo.Update(orderDB);
        }
    }
}
