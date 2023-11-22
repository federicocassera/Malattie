using Malattie.Controllers;
using Malattie.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malattie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureService(services);
            services
                .AddSingleton<start, start>()
                .BuildServiceProvider()
                .GetService<start>()
                .Execute();
        }

        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<IpotesiEntities1 , IpotesiEntities1>();
            services.AddScoped<IDbRepository, DbRepository>();
            services.AddScoped<MalattiaController, MalattiaController>();
            services.AddScoped<InterfacciaUtente, InterfacciaUtente>();
        }

        public class start
        {
            private readonly MalattiaController _contr;
            private readonly InterfacciaUtente _iu;

            public start(MalattiaController contr, InterfacciaUtente iu)
            {
                _contr = contr;
                _iu = iu;

            }

            public void Execute()
            {
                _iu.Menu();
                Console.ReadLine();
            }
        }
    }
}
