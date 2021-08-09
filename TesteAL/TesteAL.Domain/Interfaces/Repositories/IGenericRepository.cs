using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TesteAL.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> getSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}
