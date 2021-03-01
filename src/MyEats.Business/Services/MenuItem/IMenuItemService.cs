using MyEats.Business.Models.MenuItem;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyEats.Business.Services.MenuItem
{
    public interface IMenuItemService
    {
        Task<MenuItemEntity> GetMenuItemById(int menuItemId);
        bool MenuItemExists(int menuItemId);

        Task<decimal> GetMenuItemPrice(int menuItemId);
    }
}
