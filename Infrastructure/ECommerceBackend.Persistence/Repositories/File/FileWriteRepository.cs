using ECommerceBackend.Application.Repositories;
using ECommerceBackend.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence.Repositories
{
    public class FileWriteRepository : WriteRepository<ECommerceBackend.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(ECommerceDbContext
            context) : base(context)
        {
        }
    }
}
