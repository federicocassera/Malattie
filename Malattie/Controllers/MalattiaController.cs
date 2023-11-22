using Malattie.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malattie.Controllers
{
    public class MalattiaController : ControllerBase
    {
        private readonly IDbRepository _dbrepo;
        public List<Malattie> malatties { get; set; } = new List<Malattie>();
        public List<Sintomi> sintomis { get; set; } = new List<Sintomi>();

        public MalattiaController(IDbRepository dbrepo)
        {
            _dbrepo = dbrepo;
        }

        public List<Malattie> GetMalatties()
        {
            return _dbrepo.GetMalattie();
        }

        public void StampaSintomi()
        {
            sintomis = _dbrepo.GetSintomi();
            Console.WriteLine("--------------------------");
            Console.WriteLine("Sintomi possibili:");
            Console.WriteLine("--------------------------");
            foreach (var sintomo in sintomis)
            {
                Console.WriteLine("sintomo:" + sintomo);
            }
        }

        public List<Sintomi> GetSintomis()
        {
            return _dbrepo.GetSintomi();
        }

        //cambiare string con sintomi per utilizzare oggetto sintomi con metodo getsintomobyid
        //ricercare per ogni elemeto di lista di sintomi getmalattia bysintomo e salvarlo in lista malattie
        //step sopra doivrebbe essere fatto
        //da fare:
        //correggere stampa duplicata della malattia

        public Sintomi FindSintomo(string idSintomi)
        {
            var sintomoToAdd = _dbrepo.GetSintomoById(idSintomi);
            if (sintomoToAdd == null)
            {
                Console.WriteLine("Sintomo non trovato");
                return null;
            }            
            sintomis.Add(sintomoToAdd);                
            
            return sintomoToAdd;
        }

        public void FindMalattia(List<Sintomi> sintomi)
        {
            List<Malattie> malaPossibili = new List<Malattie>();

            if(sintomi != null)
            {
                foreach (var sintomo in sintomi)
                {
                    malatties.Add(_dbrepo.GetMalattiaBySintomo(sintomo));
                }

                for (int i = 0; i < malatties.Count; i++)
                {
                    for (int j = 1; j < malatties.Count; j++)
                    {
                        if (malatties[i] == malatties[j])
                        {
                            malaPossibili.Add(malatties[i]);
                        }
                    }
                }
                    //List<string> codiciMal = new List<string>();

                    //foreach (var sintomo in sintomi)
                    //{
                    //    codiciMal.AddRange(_dbrepo.SplitSintomi(sintomo));
                    //}
                    //for (int i = 0; i < codiciMal.Count; i++)
                    //{
                    //    for (int j = 1; j < codiciMal.Count; j++)
                    //    {
                    //        if (codiciMal[i] == codiciMal[j])
                    //        {
                    //            malatties.Add(_dbrepo.GetMalattiaBySintomo(codiciMal[i]));
                    //        }
                    //    }
                    //}

                    startDiagnosi(malaPossibili);
            }
            else
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Nessuna malattia relativa al sintomo...");
            }
            
        }

        public void startDiagnosi(List<Malattie> malattie)
        {
            foreach (var malattia in malattie)
            {
                if (malattia != null)
                {
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("probabile malattia: " + malattia.Malattia);
                }
            }
        }
    }
}
