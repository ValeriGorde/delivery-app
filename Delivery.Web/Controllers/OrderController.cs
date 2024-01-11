using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Delivery.BLL.Contracts.Interfaces;
using Delivery.Web.Models;
using Delivery.BLL.Models;

namespace Delivery.Web.Controllers
{
    /// <summary>
    /// Реализация контроллера заказа
    /// </summary>
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр всех заказов
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrders();
            return View(_mapper.Map<IEnumerable<OrderViewModel>>(orders));
        }


        [HttpGet]   
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Создание заказа
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel orderVM)
        {
            if (ModelState.IsValid)
            {
                var orderDto = _mapper.Map<OrderDTO>(orderVM);
                await _orderService.CreateOrder(orderDto);

                return RedirectToAction("Index");   
            }

            return View(orderVM);
        }


        /// <summary>
        /// Просмотр заказа по его id
        /// </summary>
        /// <param name="id"></param>
        [HttpGet]
        public async Task<IActionResult> ViewOrder(Guid id)
        {
            var order = await _orderService.GetOrderById(id);
            return View(_mapper.Map<OrderViewModel>(order));
        }

        /// <summary>
        /// Удаление заказа по id
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _orderService.DeleteOrderById(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Получение заказа для редактирования
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var orderDto = await _orderService.GetOrderById(id);
            
            return View(_mapper.Map<OrderViewModel>(orderDto));
        }

        public async Task<IActionResult> Edit(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.UpdateOrder(_mapper.Map<OrderDTO>(order));
                return RedirectToAction("Index");
            }
            return View(order);
        }
    }
}
