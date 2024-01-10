using Delivery.DAL.Models;
using Delivery.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.DAL.Repositories.Base
{
    /// <summary>
    /// Класс для расширения репозитория для заказа
    /// </summary>
    public interface IOrderRepository: IRepository<Order>
    {
    }
}
