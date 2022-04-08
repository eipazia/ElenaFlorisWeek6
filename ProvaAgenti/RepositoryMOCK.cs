using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    internal class RepositoryMOCK : IRepository
    {
       
            private static List<Agente> agenti = new List<Agente>()
        {
            new Agente("Mario", "Rossi", "cfmr","Roma", 1999),
            new Agente("Giuseppe", "Gialli", "cfgg","Cagliari", 1985),
            new Agente("Luigi", "verdi", "cflv","Cagliari", 1991)
        };

            public bool Aggiungi(Agente item)
            {

            if (item != null)
                {
                    var agentesistente = GetByCodiceFiscale(item.CodiceFiscale);
                    if (agentesistente == null)
                    {
                        agenti.Add(item);
                        return true;
                    }
                }
                return false;
            }

            public List<Agente> GetAll()
            {
                return agenti;
            }

            public Agente GetByArea(string area)
            {
                foreach (var item in agenti)
                {
                    if (item.AreaGeografica == area)
                    {
                        return item;
                    }
                }
                return null;
            }


       
        public Agente GetByCodiceFiscale(string codice)
        {
            foreach (var item in agenti)
            {
                if (item.CodiceFiscale == codice)
                {
                    return item;
                }
            }
            return null;
        }

    }
    }

