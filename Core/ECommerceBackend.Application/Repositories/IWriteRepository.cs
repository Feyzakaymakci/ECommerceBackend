using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddAsync(List<T> model);
        Task<bool> Remove(T model);
        Task<bool> Remove(string id); //Idsini verdiğimiz değeri de silebilsin.
        Task<bool> UpdateAsync(T model); 
    }
}
