using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;


namespace NivelStocareDate
{
    public class GestionareComenziRestaurant_FisierText
    {
        private const int NR_MAX_COMENZI = 50;
        private string numeFisier;

        public GestionareComenziRestaurant_FisierText(string numeFisier)
        {
            if (string.IsNullOrEmpty(numeFisier))
                throw new ArgumentNullException(nameof(numeFisier), "Numele fișierului nu poate fi null sau gol.");

            this.numeFisier = numeFisier;
            
                // se incearca deschiderea fisierului in modul OpenOrCreate
                // astfel incat sa fie creat daca nu exista
                using (Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate))
                {
                    // Fișierul este creat/deschis cu succes
                }
            }
           
        

        public void AddComanda(ComandaRestaurant comanda)
        {
            if (comanda == null)
                throw new ArgumentNullException(nameof(comanda), "Comanda nu poate fi null.");

            
                using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
                {
                    string linieComanda = comanda.ConversieLaSir_PentruFisier();
                    if (!string.IsNullOrEmpty(linieComanda))
                    {
                        streamWriterFisierText.WriteLine(linieComanda);
                    }
                }
            }
           
        

        public ComandaRestaurant[] GetComenzi(out int nrComenzi)
        {
            ComandaRestaurant[] comenzi = new ComandaRestaurant[NR_MAX_COMENZI];
            nrComenzi = 0;

            try
            {
                if (!File.Exists(numeFisier))
                    return comenzi;

                using (StreamReader streamReader = new StreamReader(numeFisier))
                {
                    string linieFisier;

                    while ((linieFisier = streamReader.ReadLine()) != null && nrComenzi < NR_MAX_COMENZI)
                    {
                        if (!string.IsNullOrEmpty(linieFisier))
                        {
                            try
                            {
                                comenzi[nrComenzi] = new ComandaRestaurant(linieFisier);
                                nrComenzi++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Eroare la procesarea liniei: {ex.Message}");
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Eroare la citirea din fișier: {ex.Message}", ex);
            }

            return comenzi;
        }

        public ComandaRestaurant GetComanda(int idComanda)
        {
            if (idComanda <= 0)
                throw new ArgumentException("ID-ul comenzii trebuie să fie mai mare decât 0.", nameof(idComanda));

            try
            {
                if (!File.Exists(numeFisier))
                    return null;

                using (StreamReader streamReader = new StreamReader(numeFisier))
                {
                    string linieFisier;

                    while ((linieFisier = streamReader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrEmpty(linieFisier))
                        {
                            try
                            {
                                ComandaRestaurant comanda = new ComandaRestaurant(linieFisier);
                                if (comanda != null && comanda.IDComanda == idComanda)
                                    return comanda;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Eroare la procesarea liniei: {ex.Message}");
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException($"Eroare la citirea din fișier: {ex.Message}", ex);
            }

            return null;
        }
        public bool UpdateComanda(ComandaRestaurant comandaActualizata)
        {
            ComandaRestaurant[]  comenzi = GetComenzi(out int NrComenzi);
            bool actualizareCuSucces = false;

            using (StreamWriter streamWriter = new StreamWriter(numeFisier, false))
            {
                for (int i=0;i<NrComenzi;i++)
                { 
                    ComandaRestaurant comandaPentruScriereInFisier = comenzi[i];
                    if (comandaPentruScriereInFisier.IDComanda == comandaActualizata.IDComanda)
                    {
                        comandaPentruScriereInFisier = comandaActualizata;
                        actualizareCuSucces = true;
                    }
                    streamWriter.WriteLine(comandaPentruScriereInFisier.ConversieLaSir_PentruFisier());

                }
            }
            return actualizareCuSucces;
        }
    }
}
