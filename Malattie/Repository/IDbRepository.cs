using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malattie.Repository
{
    public interface IDbRepository
    {
        List<Malattie> GetMalattie();
        List<Sintomi> GetSintomi();
        Malattie GetMalattiaBySintomo(Sintomi sintomo);
        Sintomi GetSintomoById(string id);
        List<string> SplitSintomi(Sintomi sin);
    }
}
