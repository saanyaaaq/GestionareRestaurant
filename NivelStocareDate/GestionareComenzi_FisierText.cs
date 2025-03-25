using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class GestionareComenzi_FisierText
    {
        private const int NR_MAX_COMENZI = 100;
        private string numeFisier;

        public GestionareComenzi_FisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisier = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisier.Close();
        }

        public void AddComanda(Comanda comanda)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisier, true))
            {
                streamWriter.WriteLine(comanda.ConversieLaSir_PentruFisier());
            }
        }

        public Comanda[] GetComenzi(out int nrComenzi)
        {
            Comanda[] comenzi = new Comanda[NR_MAX_COMENZI];
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrComenzi = 0;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    comenzi[nrComenzi++] = new Comanda(linieFisier);
                }
            }
            return comenzi;
        }

        public Comanda CautareDupaIDComanda(int idComanda)
        {
            Comanda[] comenzi = GetComenzi(out int nrComenzi);
            return comenzi.FirstOrDefault(comanda => comanda != null && comanda.IDComanda == idComanda);
        }

        public Comanda CautareDupaNrMasa(int nrMasa)
        {
            Comanda[] comenzi = GetComenzi(out int nrComenzi);
            return comenzi.FirstOrDefault(comanda => comanda != null && comanda.NrMasa == nrMasa);
        }
    }
}
