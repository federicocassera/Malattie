using Malattie.Controllers;
using Malattie.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malattie
{
    public class InterfacciaUtente
    {
        private readonly MalattiaController _controller;

        List<Sintomi> sintomi = new List<Sintomi>();

        public InterfacciaUtente(MalattiaController controller)
        {
            _controller = controller;
        }

        public void Menu()
        {
            //bool cont = true;           

            while (true)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("inserire sintomo:");

                var sintomo = Console.ReadLine();
                sintomi.Add(_controller.FindSintomo(sintomo));

                Console.WriteLine("--------------------------");
                Console.WriteLine("inserire 1 per iniziare la diagnosi ...");
                Console.WriteLine("inserire 2 per digitare altri sintomi ...");
                Console.WriteLine("--------------------------");
                string scelta = Console.ReadLine();

                switch(scelta)
                {
                    case "1":
                        _controller.FindMalattia(sintomi);
                        break;
                    default:
                        break;
                        
                }

            }
        }
    }
}
