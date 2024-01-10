﻿using Microsoft.AspNetCore.Mvc;
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


    }
}
