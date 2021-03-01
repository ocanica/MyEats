using MyEats.Domain;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Repository.InOrder
{
    public class InOrderRepository : RepositoryBase<InOrderEntity>, IInOrderRepository
    {
        public InOrderRepository(MyEatsDataContext context)
            : base(context) 
        { 
        }
    }
}
