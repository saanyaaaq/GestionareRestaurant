﻿using LibrarieModele;
using System;
using System.IO;

namespace NivelStocareDate
{
    public class GestionareComenziRestaurant_FisierText
    {
        private const int NR_MAX_COMENZI = 50;
        private string numeFisier;

        public GestionareComenziRestaurant_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddComanda(ComandaRestaurant comanda)
        {
            try
            {
                using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
                {
                    streamWriterFisierText.WriteLine(comanda.ConversieLaSir_PentruFisier());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la scrierea în fișier: {ex.Message}");
            }
        }

        public ComandaRestaurant[] GetComenzi(out int nrComenzi)
        {
            ComandaRestaurant[] comenzi = new ComandaRestaurant[NR_MAX_COMENZI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrComenzi = 0;

                // citeste cate o linie si creaza un obiect de tip ComandaRestaurant
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    comenzi[nrComenzi++] = new ComandaRestaurant(linieFisier);
                }
            }
            
            return comenzi;
        }
        public ComandaRestaurant GetComanda(int idComanda)
        {
            // Folosește 'using' pentru a închide automat StreamReader
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;

                // Citește fiecare linie din fișier
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    // Creează un obiect de tip Comanda pe baza liniei citite
                    ComandaRestaurant comanda = new ComandaRestaurant(linieFisier);

                    // Verifică dacă ID-ul comenzii corespunde
                    if (comanda.IDComanda == idComanda)
                        return comanda;
                }
            }

            // Returnează null dacă nu a fost găsită nicio comandă cu ID-ul specificat
            return null;
        }
    }
}
