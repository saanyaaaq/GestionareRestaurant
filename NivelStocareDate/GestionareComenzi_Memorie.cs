using System;
using System.Collections.Generic;
using LibrarieModele;
using System.Linq;

namespace RestaurantManagement.Models
{
    public class GestionareComenzi_Memorie
    {
        public List<Comanda> Comenzi { get; set; }
        private const int NR_MAX_COMENZI = 100;
        public int CapacitateMaxima { get; set; }
        private int nrcComenzi;
        private Comanda[] cam;

        // Constructor fără parametri
        public GestionareComenzi_Memorie()
        {
            Comenzi = new List<Comanda>();
            CapacitateMaxima = 0;
        }

        // Constructor cu parametri
        public GestionareComenzi_Memorie(int capacitateMaxima)
        {
            Comenzi = new List<Comanda>();
            CapacitateMaxima = capacitateMaxima;
        }

        // Metodă pentru adăugarea unei comenzi
       

        // Metodă pentru listarea comenzilor
        public void AfiseazaComenzi()
        {
            foreach (var comanda in Comenzi)
            {
                Console.WriteLine(comanda.Info());
            }
        }
        public Comanda[] GetComenzi(out int nrComenzi)
        {
            nrComenzi = Comenzi.Count;
            return Comenzi.ToArray();
        }

        // Metodă pentru căutarea unei comenzi după ID
        public Comanda CautaComandaDupaID(int idComanda)
        {
            foreach (var comanda in Comenzi)
            {
                if (comanda.IDComanda == idComanda)
                {
                    return comanda;
                }
            }
            return null;
        }

        // Metodă pentru căutarea unei comenzi după numărul mesei
        public Comanda CautaComandaDupaNrMasa(int nrMasa)
        {
            foreach (var comanda in Comenzi)
            {
                if (comanda.NrMasa == nrMasa)
                {
                    return comanda;
                }
            }
            return null;
        }
    }
}
