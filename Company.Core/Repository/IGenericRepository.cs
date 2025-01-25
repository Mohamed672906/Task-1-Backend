using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Core.Entites;

namespace Company.Core.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int Id);

        Task AddAsync(T item);

        void Update(T item);

        void Delete(T item);




    }
}
