using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malattie.Repository
{
    class DbRepository : IDbRepository
    {
        private IpotesiEntities1 _ctx;

        public DbRepository(IpotesiEntities1 ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public Malattie GetMalattiaBySintomo(Sintomi sintomo)
        {
            Malattie malToReturn = null;
            foreach (var sin in SplitSintomi(sintomo))
            {
                malToReturn = _ctx.Malattie.FirstOrDefault(m => m.Codice == sin);                
            }
            return malToReturn;
        }

        public List<Malattie> GetMalattie()
        {
            var mal = _ctx.Malattie.ToList();
            return mal;
        }

        public List<Sintomi> GetSintomi()
        {
            return _ctx.Sintomi.ToList();
        }

        public Sintomi GetSintomoById(string id)
        {
            var sintomo = _ctx.Sintomi.FirstOrDefault(sin => sin.Codice == id);
            
            return sintomo;
        }

        public List<string> SplitSintomi(Sintomi sin)
        {
            try
            {
                var sintomo = _ctx.Sintomi.FirstOrDefault(x => x.Codice == sin.Codice);
                List<string> malattiePoss = sintomo.Numeri.Split(' ').ToList();                
                return malattiePoss;
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                Console.WriteLine("Sintomo non presente");
                return null;
            }

            
        }
    }
}
