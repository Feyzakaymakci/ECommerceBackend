using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.Persistence
{
    public class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceBackend.API"));
                    configurationManager.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.Production.json");
                }

                return configurationManager.GetConnectionString("PostgreSQL");
            }
        }
    }
}
