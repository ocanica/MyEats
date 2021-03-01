using AutoMapper;
using Microsoft.Extensions.Logging;
using MyEats.Business.Models.MenuItem;
using MyEats.Business.Repository;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEats.Business.Services.MenuItem
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ILogger<MenuItemService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MenuItemService(ILogger<MenuItemService> logger, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MenuItemEntity> GetMenuItemById(int menuItemId)
        {
            _logger.LogDebug($"{nameof(MenuItemService)} init {nameof(GetMenuItemById)}");

            var menuItem = await _unitOfWork.MenuItems.GetAsync(menuItemId);

            //var result = _mapper.Map<UserModel>(user);

            _logger.LogDebug($"{nameof(MenuItemService)} end {nameof(GetMenuItemById)}");

            return menuItem;
        }

        public async Task<decimal> GetMenuItemPrice(int menuItemId)
        {
            _logger.LogDebug($"{nameof(MenuItemService)} init {nameof(GetMenuItemPrice)}");

            var menuItem = await _unitOfWork.MenuItems.GetAsync(menuItemId);

            return menuItem.Price;
        }

        public bool MenuItemExists(int menuItemId)
        {
            _logger.LogDebug($"{nameof(MenuItemService)} init {nameof(MenuItemExists)}");

            var exists = _unitOfWork.MenuItems.Find(x => x.MenuItemId == menuItemId).Any();

            _logger.LogDebug($"{nameof(MenuItemService)} end {nameof(MenuItemExists)}");

            return exists;
        }
    }
}
