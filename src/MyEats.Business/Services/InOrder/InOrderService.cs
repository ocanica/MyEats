using AutoMapper;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models.InOrder;
using MyEats.Business.Repository;
using MyEats.Business.Services.MenuItem;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEats.Business.Services.InOrder
{
    public class InOrderService : IInOrderService
    {
        private readonly ILogger<InOrderService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMenuItemService _menuItemService;

        public InOrderService(ILogger<InOrderService> logger,
            IUnitOfWork unitOfWork,
            IMapper mapper, IMenuItemService menuItemService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _menuItemService = menuItemService;
        }

        public IEnumerable<InOrderEntity> GetInOrdersByOrderId(int orderId)
        {
            var inOrders = _unitOfWork.InOrders.Find(x => x.OrderId == orderId);

            return inOrders;
        }

        public async Task<InOrderEntity> GetInOrderByOrderAndMenuItemsIds(int orderId, int menuItemId)
        {
            _logger.LogDebug($"{nameof(InOrderService)} init {nameof(GetInOrderByOrderAndMenuItemsIds)}");

            var inOrder = _unitOfWork.InOrders.Find(x => x.OrderId == orderId && x.MenuItemId == menuItemId ).FirstOrDefault();

            //var result = _mapper.Map<InOrderModel>(inOrder);

            _logger.LogDebug($"{nameof(InOrderService)} end {nameof(GetInOrderByOrderAndMenuItemsIds)}");

            return inOrder;
        }

        public async Task UpdateInOrderPrices()
        {
            _logger.LogDebug($"{nameof(InOrderService)} init {nameof(UpdateInOrderPrices)}");

            var query = from i in _unitOfWork.InOrders.List()
                        join m in _unitOfWork.MenuItems.List()
                        on i.MenuItemId equals m.MenuItemId
                        where i.MenuItemId == m.MenuItemId
                        select new
                        {
                            inOrder = i,
                            menu = m
                        };

            foreach (var item in query)
            {
                item.inOrder.Price = item.inOrder.Quantity * item.menu.Price;
            }

            await _unitOfWork.Save();
        }

        public bool InOrderExists(int inOrderId)
        {
            _logger.LogDebug($"{nameof(InOrderService)} init {nameof(InOrderExists)}");

            var exists = _unitOfWork.InOrders.Find(x => x.InOrderId == inOrderId).Any();

            _logger.LogDebug($"{nameof(InOrderService)} end {nameof(InOrderExists)}");

            return exists;
        }
    }
}
