using System;
using System.Collections.Generic;
using LibrarieModele;
namespace RestaurantManagement.Models
{
    public class GestionareComenziRestaurant
    {
        public List<ComandaRestaurant> Comenzi { get; set; }
        public int CapacitateMaxima { get; set; }

        // Constructor fără parametri

        public GestionareComenziRestaurant()
        {
            Comenzi = new List<ComandaRestaurant>();
            CapacitateMaxima = 0;
        }

        // Constructor cu parametri
        public GestionareComenziRestaurant(int capacitateMaxima)
        {
            Comenzi = new List<ComandaRestaurant>();
            CapacitateMaxima = capacitateMaxima;
        }

        // Metodă pentru adăugarea unei comenzi
        public bool AdaugaComanda(ComandaRestaurant comanda)
        {
            if (Comenzi.Count < CapacitateMaxima)
            {
                Comenzi.Add(comanda);
                return true;
            }
            return false;
        }

        // Metodă pentru listarea comenzilor
        public void AfiseazaComenzi()
        {
            foreach (var comanda in Comenzi)
            {
                Console.WriteLine(comanda.Info());
            }
        }
    }
}
