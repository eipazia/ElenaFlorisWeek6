using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    internal class Agente : Persona
    {
        public string AreaGeografica { get; set; }
        public int AnnoInizioAttivita { get; set; }

        public int AnniServizio { get { return CalcolaAnniServizio(); } }

        public Agente()
        {
                
        }
       
        public Agente(string nome, string cognome, string codice,string areag, int annoinizioattivita)
                                     :base(nome,cognome,codice)
        {
            AreaGeografica = areag;
            AnnoInizioAttivita = annoinizioattivita;
           
        }

        protected int CalcolaAnniServizio()
        {
            return DateTime.Now.Year - AnnoInizioAttivita;
        }
        public override string ToString()
        {
            return $"CF:{CodiceFiscale} - Nome:{Nome} - Cognome {Cognome} - Anni di Servizio {AnniServizio}";
        }
    }
}
