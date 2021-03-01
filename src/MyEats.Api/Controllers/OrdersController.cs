using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models.Order;
using MyEats.Business.Services.Order;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyEats.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Orders controller")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _service;

        public OrdersController(ILogger<OrdersController> logger, IOrderService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, "List of user details", typeof(IEnumerable<OrderModel>))]
        [SwaggerResponse(404, description: "Unable to retrieve orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            _logger.LogInformation($"Request received {nameof(OrdersController)} at {nameof(GetAllOrders)} endpoint");

            var result = await _service.GetAllOrders();

            return Ok(result);
        }

        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns></returns>
        [HttpGet("{orderId}")]
        [SwaggerResponse(200, "Retrieved users", typeof(OrderModel))]
        [SwaggerResponse(400, description: "Something went wrong while retrieving the order")]
        [SwaggerResponse(404, description: "Unable to retrieve order record")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            _logger.LogInformation($"Request received {nameof(OrdersController)} at {nameof(GetOrderById)} endpoint");

            if (!_service.OrderExists(orderId))
                return NotFound("Order identfier not found.");

            var result = await _service.GetOrderById(orderId);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse(201, "Item added", typeof(AddToOrderModel))]
        [SwaggerResponse(400, "Something went wrong while creating the user")]
        public async Task<IActionResult> AddToOrder(AddToOrderModel orderModel)
        {
            _logger.LogInformation($"Request received {nameof(OrdersController)} at {nameof(AddToOrder)} endpoint");

            await _service.AddItemToOrder(orderModel.OrderId, orderModel.MenuItemId, orderModel.Quantity);

            return Ok();
        }
    }
}
