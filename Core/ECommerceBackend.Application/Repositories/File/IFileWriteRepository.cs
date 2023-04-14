using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using F = ECommerceBackend.Domain.Entities;

namespace ECommerceBackend.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<F::File>
    {
    }
}
