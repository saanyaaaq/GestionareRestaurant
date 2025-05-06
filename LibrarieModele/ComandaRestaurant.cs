using System;
using System.Collections;

namespace LibrarieModele
{
    public class ComandaRestaurant
    {
        // Константы для разделения в файле
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';

        private const int ID_COMANDA = 0;
        private const int NR_MASA = 1;
        private const int PRET_TOTAL = 2;
        private const int STARE_COMANDA = 3;
        private const int DESCRIERE_MENIU = 4;
        private const int OPTIUNI_MENIU = 5;

        public int IDComanda { get; set; }
        public Enumerare.Mese NrMasa { get; set; }
        public double PretTotal { get; set; }
        public string StareComanda { get; set; }
        public MeniuRestaurant Menu { get; set; }

        public ArrayList OptiuniMeniu { get; set; }

        public string OptiuniMeniuAsString
        {
            get
            {
                return string.Join(SEPARATOR_SECUNDAR_FISIER.ToString(), OptiuniMeniu.ToArray());
            }
        }

        // Конструктор без параметров
        public ComandaRestaurant()
        {
            IDComanda = 0;
            NrMasa = Enumerare.Mese.Masa1;
            PretTotal = 0.0;
            StareComanda = string.Empty;
            Menu = new MeniuRestaurant();
            OptiuniMeniu = new ArrayList();
        }

        // Конструктор с параметрами
        public ComandaRestaurant(int idComanda, Enumerare.Mese nrMasa, double pretTotal, string stareComanda, MeniuRestaurant menu, ArrayList optiuniMeniu)
        {
            IDComanda = idComanda;
            NrMasa = nrMasa;
            PretTotal = pretTotal;
            StareComanda = stareComanda ?? string.Empty;
            Menu = menu;
            OptiuniMeniu = optiuniMeniu;
        }

        // Конструктор, который принимает данные из строки файла
        public ComandaRestaurant(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            IDComanda = int.Parse(date[ID_COMANDA]);
            NrMasa = (Enumerare.Mese)Enum.Parse(typeof(Enumerare.Mese), date[NR_MASA]);
            PretTotal = double.Parse(date[PRET_TOTAL]);
            StareComanda = date[STARE_COMANDA] ?? string.Empty;
            Menu = new MeniuRestaurant(date[DESCRIERE_MENIU]);

            OptiuniMeniu = new ArrayList();
            OptiuniMeniu.AddRange(date[OPTIUNI_MENIU].Split(SEPARATOR_SECUNDAR_FISIER));
        }

        public string OptiuniMeniuToString()
        {
            return string.Join(", ", OptiuniMeniu.ToArray());
        }
        public string GetNrMasaText()
        {
            switch (NrMasa)
            {
                case Enumerare.Mese.Masa1:
                    return "Masa 1";
                case Enumerare.Mese.Masa2:
                    return "Masa 2";
                case Enumerare.Mese.Masa3:
                    return "Masa 3";
                case Enumerare.Mese.Masa4:
                    return "Masa 4";
                case Enumerare.Mese.Masa5:
                    return "Masa 5";
                default:
                    return "Masa necunoscuta";
            }
        }


        public string Info()
        {
            return $"ID Comanda: {IDComanda}\nMasa: {NrMasa}\nPret Total: {PretTotal}\nStare: {StareComanda}\nMeniu: {Menu?.Info() ?? "N/A"}\nOptiuni Meniu: {OptiuniMeniuAsString}\n";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                SEPARATOR_PRINCIPAL_FISIER,
                IDComanda,
                NrMasa,
                PretTotal,
                StareComanda,
                Menu.Descriere, // Добавляем описание меню
                OptiuniMeniuAsString);
        }
       
        }
    }

