using MyEats.Domain;
using MyEats.Domain.Entities;
using MyEats.Business.Repository.Contracts;

namespace MyEats.Business.Repository
{
    public class CustomersRepository : RepositoryBase<Customer>, ICustomersRepository
    {
        public CustomersRepository(DataContext context)
            : base(context)
        {
        }

        // Deprecated. For reference use.

        //public override Task AddAsync(Customer entity)
        //{
        //    try
        //    {
        //        var postCodeId = from p in base.context.PostCodes
        //                         where p.Town.Contains(entity.Town)
        //                         select p.Id;

        //        entity.PostCodeId = postCodeId.FirstOrDefault();
        //        entity.DateRegistered = DateTime.Now;
        //    }
        //    catch (SqlException exception)
        //    {
        //        throw new Exception(exception.Message);
        //    }

        //    return base.Add(entity);
        //}
    }
}
