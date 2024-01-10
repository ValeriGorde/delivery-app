using Delivery.DAL.Data;
using Delivery.DAL.Models;
using Delivery.DAL.Repositories.Base;

namespace Delivery.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
