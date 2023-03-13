using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
            => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
            =>Table.Where(method);



        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        =>await  Table.FirstOrDefaultAsync(method);

        public Task<T> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

    }
}
