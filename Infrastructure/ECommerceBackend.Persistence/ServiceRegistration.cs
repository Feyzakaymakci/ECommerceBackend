using ECommerceBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence
{
    // Bu sınıf IoC container ımın arayüzüne bir extension fonksiyon sağlıyor. Bu fonksiyon üzerinden ben direkt IoC container ıma datalarımı gönderiyorum. 
    public static class ServiceRegistration
    {
      public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));
        }
    }
}
