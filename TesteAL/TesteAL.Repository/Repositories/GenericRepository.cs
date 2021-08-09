using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteAL.Domain.Interfaces.Repositories;
using TesteAL.Repository.Context;

namespace TesteAL.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TesteALContext _db;

        public GenericRepository(TesteALContext db)
        {
            _db = db;
        }
        public async Task<T> Add(T entity)
        {

            _db.Set<T>().Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IEnumerable<T> list;
            IQueryable<T> dbQuery = _db.Set<T>();

            if (navigationProperties != null)
            {
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, include) => current.Include(include));
            }

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = await dbQuery
               .AsNoTracking()
               .ToListAsync<T>();
            return list;
        }

        public async Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IEnumerable<T> list;
            IQueryable<T> dbQuery =  _db.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            dbQuery = dbQuery
                .AsNoTracking()
                .Where(where).AsQueryable<T>();

            list = await dbQuery
                .ToListAsync<T>();
            return list;
        }

        public async Task<T> getSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _db.Set<T>();
            var query = dbQuery.AsQueryable<T>();

            navigationProperties.ToList().ForEach(i => query = query.Include(i));

            return await query.Where(where).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task Update(T entity)
        {
            _db.Set<T>().Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
