using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyEats.Business.Helper;
using MyEats.Business.Models.Order;
using MyEats.Business.Repository;
using MyEats.Business.Services.InOrder;
using MyEats.Business.Services.MenuItem;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEats.Business.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IInOrderService _inOrderService;
        private readonly IMenuItemService _menuItemService;


        public OrderService(ILogger<OrderService> logger, 
            IUnitOfWork unitOfWork,
            IMapper mapper, IInOrderService inOrderService,
            IMenuItemService menuItemService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _inOrderService = inOrderService;
            _menuItemService = menuItemService;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            _logger.LogDebug($"{nameof(OrderService)} init {nameof(GetAllOrders)}");

            var orders = await _unitOfWork.Orders.List().Include(x => x.InOrders).ToListAsync();

            var result = _mapper.Map<IEnumerable<OrderModel>>(orders);

            _logger.LogDebug($"{nameof(OrderService)} end {nameof(GetAllOrders)}");

            return result;
        }

        public async Task<OrderEntity> GetOrderById(int orderId)
        {
            _logger.LogDebug($"{nameof(OrderService)} init {nameof(GetOrderById)}");

            var orders = await _unitOfWork.Orders.List().Include(x => x.InOrders).Where(x => x.OrderId == orderId).FirstOrDefaultAsync();

            //var result = _mapper.Map<OrderModel>(orders);

            _logger.LogDebug($"{nameof(OrderService)} end {nameof(GetOrderById)}");

            return orders;
        }

        public bool OrderExists(int orderId)
        {
            _logger.LogDebug($"{nameof(OrderService)} init {nameof(OrderExists)}");

            var exists = _unitOfWork.Orders.Find(x => x.OrderId == orderId).Any();

            _logger.LogDebug($"{nameof(OrderService)} end {nameof(OrderExists)}");

            return exists;
        }

        public async Task AddItemToOrder(int orderId, int menuItemId, int quantity)
        {
            var rand = new Random();
            try
            {
                var order = await GetOrderById(orderId);
                var inOrder = await _inOrderService.GetInOrderByOrderAndMenuItemsIds(orderId, menuItemId);

                if (inOrder != null)
                {
                    inOrder.Quantity += quantity;

                    await _inOrderService.UpdateInOrderPrices();

                    return;
                }

                var menuItem = await _menuItemService.GetMenuItemById(menuItemId);
                var inOrderId = rand.Next(10000, 99999);

                if (!_menuItemService.MenuItemExists(menuItemId))
                {
                    var modelToCreate = new InOrderEntity()
                    {
                        InOrderId = inOrderId,
                        OrderId = orderId,
                        MenuItemId = menuItem.MenuItemId,
                        Price = menuItem.Price,
                        Quantity = quantity
                    };

                    await _unitOfWork.InOrders.AddAsync(modelToCreate);

                    order.TotalPrice = _unitOfWork.InOrders.List().
                        Where(x => x.OrderId == order.OrderId).Select(p => p.Price).Sum();
                    order.Items = _unitOfWork.InOrders.List().
                        Where(x => x.OrderId == order.OrderId).Select(q => q.Quantity).Sum();

                    await _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating new Order. Error {ex.InnerException}");
                throw new Exception(ex.Message);
            }

        }
    }
}
