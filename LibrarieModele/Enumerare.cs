using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Enumerare
    {
        public enum Mese
        {
            Masa1 = 1,
            Masa2 = 2,
            Masa3 = 3,
            Masa4 = 4,
            Masa5 = 5,
        }

        public enum StareComanda
        {
            InAsteptare,
            InPreparare,
            Gata,
            Livrata,
            Anulata
        }
    }
}
