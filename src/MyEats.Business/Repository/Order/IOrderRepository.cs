using MyEats.Business.Models;
using MyEats.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MyEats.Business.Repository
{
    public interface IOrderRepository : IBaseRepository<OrderEntity>
    {

    }
}