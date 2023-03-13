using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method); //Where şartı mahiyetinde kullanıcaz.
        Task <T> GetSingleAsync(Expression<Func<T, bool>> method); //Şarta uygun olan ilk tekil nesneyi getirecek.
        Task <T> GetByIdAsync(string id); //Id ye uygun olan hangisiyse onu getirecek.


    }
}
