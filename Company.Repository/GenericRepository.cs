using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Entites;
using Company.Core.Repository;
using Company.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly StoreContext _storeContext;

        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }


        public Task AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _storeContext.Set<T>().FindAsync(Id);
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
