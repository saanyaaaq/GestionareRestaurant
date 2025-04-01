using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelStocareDate
{
    public class GestionareComenziRestaurant_Memorie
    {
        private const int NR_MAX_COMENZI = 100;
        private ComandaRestaurant[] comenzi;
        private int nrComenzi;

        public GestionareComenziRestaurant_Memorie()
        {
            comenzi = new ComandaRestaurant[NR_MAX_COMENZI];
            nrComenzi = 0;
        }
        public void AddComanda(ComandaRestaurant comanda)
        {
            comenzi[nrComenzi] = comanda;
            nrComenzi++;
        }

        public ComandaRestaurant[] GetComenzi(out int nrComenzi)
        {
            nrComenzi = this.nrComenzi;
            return comenzi;
        }
        public ComandaRestaurant CautareDupaIDComanda(int idComanda)
        {
            foreach (var comanda in comenzi)
            {
                if (comanda != null && comanda.IDComanda == idComanda)
                {
                    return comanda;
                }
            }
            return null;
        }
    }
}
       