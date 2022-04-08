using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAgenti
{
    internal interface IRepository
    {
        internal interface IRepository<T>
        {
            List<T> GetAll();
            T GetByArea(string areag);
            T GetByAnniServizio(int annoinizioattivita);
            T GetByCodiceFiscale(string codice);
            bool Aggiungi(T item);
        }
    }
}
