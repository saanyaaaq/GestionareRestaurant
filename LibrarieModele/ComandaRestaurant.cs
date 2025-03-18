using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class ComandaRestaurant
    {
        // Constante pentru delimitarea în fișier
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID_COMANDA = 0;
        private const int NR_MASA = 1;
        private const int PRET_TOTAL = 2;
        private const int STARE_COMANDA = 3;
        private const int DESCRIERE_MENIU = 4;

        public int IDComanda { get; set; }
        public int NrMasa { get; set; }
        public double PretTotal { get; set; }
        public string StareComanda { get; set; }
        public MenuRestaurant Menu { get; set; }

        // Constructor fara parametri
        public ComandaRestaurant()
        {
            IDComanda = 0;
            NrMasa = 0;
            PretTotal = 0.0;
            StareComanda = string.Empty;
            Menu = new MenuRestaurant();
        }

        // Constructor cu parametri
        public ComandaRestaurant(int idComanda, int nrMasa, double pretTotal, string stareComanda, MenuRestaurant menu)
        {
            this.IDComanda = idComanda;
            this.NrMasa = nrMasa;
            this.PretTotal = pretTotal;
            this.StareComanda = stareComanda;
            this.Menu = menu;
        }

        // Constructor care preia date dintr-o linie de fișier
        public ComandaRestaurant(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            IDComanda = int.Parse(dateFisier[ID_COMANDA]);
            NrMasa = int.Parse(dateFisier[NR_MASA]);
            PretTotal = double.Parse(dateFisier[PRET_TOTAL]);
            StareComanda = dateFisier[STARE_COMANDA];
            Menu = new MenuRestaurant(dateFisier[DESCRIERE_MENIU]);
        }

        public string Info()
        {
            return $"ID: {IDComanda}, Nr Masa: {NrMasa}, Pret Total: {PretTotal}, Stare Comanda: {StareComanda}, Meniu: {Menu.Info()}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
                SEPARATOR_PRINCIPAL_FISIER,
                IDComanda,
                NrMasa,
                PretTotal,
                StareComanda,
                Menu.Descriere);
        }
    }
}
