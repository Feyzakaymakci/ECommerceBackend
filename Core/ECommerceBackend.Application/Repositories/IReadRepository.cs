using ECommerceBackend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); //Where şartı mahiyetinde kullanıcaz.
        Task <T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //Şarta uygun olan ilk tekil nesneyi getirecek.
        Task <T> GetByIdAsync(string id, bool tracking = true); //Id ye uygun olan hangisiyse onu getirecek.


    }
}
