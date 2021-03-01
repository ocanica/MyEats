using MyEats.Domain;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Repository
{
    public class MenuItemRepository : RepositoryBase<MenuItemEntity>, IMenuItemRepository
    {
        public MenuItemRepository(MyEatsDataContext context)
            : base(context)
        {
        }
    }
}
