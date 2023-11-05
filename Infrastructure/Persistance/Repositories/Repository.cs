using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DriverContext _driverContext;

        public Repository(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        public async Task CreateAsync(T t)
        {
            _driverContext.Add(t);
            await _driverContext.SaveChangesAsync();
                  
        }

        public async Task DeleteAsync(T t)
        {
           _driverContext.Remove(t);
            await _driverContext.SaveChangesAsync();
        }

        public Task<T> DeleteAsync(int ıd)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _driverContext.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _driverContext.Set<T>();
            return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));

        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _driverContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T t)
        {
            _driverContext.Update(t);
            await _driverContext.SaveChangesAsync();
        }
    }
}
