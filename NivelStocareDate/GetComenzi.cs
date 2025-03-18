using System.Collections.Generic;
using LibrarieModele;
namespace RestaurantManagement.Models
{
    public class GestionareComenzi
    {
        private List<ComandaRestaurant> comenzi;

        public GestionareComenzi()
        {
            comenzi = new List<ComandaRestaurant>();
        }

        public void AdaugaComanda(ComandaRestaurant comanda)
        {
            comenzi.Add(comanda);
        }

        public List<ComandaRestaurant> GetComenzi()
        {
            return comenzi;
        }
        public ComandaRestaurant CautaComanda(int id)
        {
            foreach (var comanda in comenzi)
            {
                if (comanda.IDComanda == id)
                {
                    return comanda;
                }
            }
            return null;
        }
    }
}
