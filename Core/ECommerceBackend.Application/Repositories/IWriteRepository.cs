using ECommerceBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model); //async kullanmıyoruz.
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T model);
        Task<int> SaveAsync(); //SaveChanges i çağırabilmemiz için bu fonksiyonu çağırıcaz.  Bunu şu yüzden yapıyoruz : her fonksiyonun içinde SaveChanges'ı çağırmak demek lüzumsuz yere her işlem sonunda bir transaction başlatmak demek

    }
}
