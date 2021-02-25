using MyEats.Domain;
using MyEats.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEats.Business.Repository
{
    public class CuisineRepository : RepositoryBase<CuisineEntity>, ICuisineRepository
    {
        public CuisineRepository(MyEatsDataContext context)
            : base(context)
        {
        }
    }
}
