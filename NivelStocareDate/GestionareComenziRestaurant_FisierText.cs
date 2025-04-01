using LibrarieModele;
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
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(comanda.ConversieLaSir_PentruFisier());
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
    }
}
