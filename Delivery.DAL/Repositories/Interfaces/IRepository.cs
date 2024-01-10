using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Базовый итерфейс репозитория
    /// </summary>
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
