using System;
using System.Configuration;
using System.IO;
using LibrarieModele;
using NivelStocareDate;

namespace GestionareRestaurant
{
    class Program
    {
        static void Main()
        {
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            GestionareComenziRestaurant_FisierText adminComenzi = new GestionareComenziRestaurant_FisierText(caleCompletaFisier);
            GestionareComenziRestaurant_Memorie adminComenziMemorie = new GestionareComenziRestaurant_Memorie();
            ComandaRestaurant comandaNoua = new ComandaRestaurant();
            int nrComenzi = 0;

            // acest apel ajuta la obtinerea numarului de comenzi inca de la inceputul executiei
            // astfel incat o eventuala adaugare sa atribuie un IDComanda corect noii comenzi
            adminComenzi.GetComenzi(out nrComenzi);

            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii comanda de la tastatura");
                Console.WriteLine("I. Afisarea informatiilor despre ultima comanda introdusa");
                Console.WriteLine("A. Afisare comenzi din fisier");
                Console.WriteLine("M. Afisare comenzi din memorie");
                Console.WriteLine("D. Salvare comenzi in memorie");
                Console.WriteLine("S. Salvare comanda in fisier");
                Console.WriteLine("L. Cautare comanda dupa ID din memorie");
                Console.WriteLine("F. Cautare comanda dupa ID din fisier");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        comandaNoua = CitesteComanda();
                        break;
                    case "I":
                        AfisareComanda(comandaNoua);
                        break;
                    case "A":
                        ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out nrComenzi);
                        AfisareComenzi(comenzi);
                        break;
                    case "M":
                        AfisareComenziMemorie(adminComenziMemorie);
                        break;
                    case "D":
                        adminComenziMemorie.AddComanda(comandaNoua);
                        break;
                    case "S":
                        int idComanda = ++nrComenzi;
                        comandaNoua.IDComanda = idComanda;
                        // adaugare comanda in fisier
                        adminComenzi.AddComanda(comandaNoua);
                        break;
                    case "L":
                        Console.Write("Introduceti ID-ul comenzii: ");
                        int idCautatMemorie = int.Parse(Console.ReadLine());
                        CautaComandaDupaIDMemorie(adminComenziMemorie, idCautatMemorie);
                        break;
                    case "F":
                        Console.Write("Introduceti ID-ul comenzii: ");
                        int idCautat = int.Parse(Console.ReadLine());
                        CautaComandaDupaID(adminComenzi, idCautat);
                        break;
                    
                    case "X":
                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        static ComandaRestaurant CitesteComanda()
        {
            Console.Write("Introdu ID comandei: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Introduceti numarul mesei (Masa1, Masa2, etc., Masa5): ");
            string nrMasaInput = Console.ReadLine();
            Enumerare.Mese nrMasa;
            while (!Enum.TryParse(nrMasaInput, out nrMasa))
            {
                Console.Write("Valoare invalida. Introduceti numarul mesei (Masa1, Masa2, etc.): ");
                nrMasaInput = Console.ReadLine();
            }

            Console.Write("Introdu Pretul Total: ");
            double pretTotal = double.Parse(Console.ReadLine());

            Console.Write("Introdu Statusul Comanda: ");
            string status = Console.ReadLine();

            Console.Write("Introdu Felul Principal: ");
            string felPrincipal = Console.ReadLine();

            Console.Write("Introdu Garnitura: ");
            string garnitura = Console.ReadLine();

            Console.Write("Introdu Bautura: ");
            string bautura = Console.ReadLine();

            Console.Write("Introdu Desertul: ");
            string desert = Console.ReadLine();

            MeniuRestaurant menu = new MeniuRestaurant(felPrincipal, garnitura, bautura, desert);
            return new ComandaRestaurant(id, nrMasa, pretTotal, status, menu);
        }

        public static void AfisareComanda(ComandaRestaurant comanda)
        {
            string infoComanda = string.Format("Comanda cu id-ul #{0} pentru masa #{1} are pretul total: {2} si starea: {3}. Meniu: {4}",
                    comanda.IDComanda,
                    comanda.NrMasa,
                    comanda.PretTotal,
                    comanda.StareComanda,
                    comanda.Menu.Info());

            Console.WriteLine(infoComanda);
        }

        public static void AfisareComenzi(ComandaRestaurant[] comenzi)
        {
            Console.WriteLine("Comenzile sunt:");
            foreach (ComandaRestaurant comanda in comenzi)
            {
                if (comanda != null)
                {
                    string infoComanda = comanda.Info();
                    Console.WriteLine(infoComanda);
                }
            }
        }

        public static void AfisareComenziMemorie(GestionareComenziRestaurant_Memorie adminComenziMemorie)
        {
            ComandaRestaurant[] comenzi = adminComenziMemorie.GetComenzi(out int nrComenzi);
            AfisareComenzi(comenzi);
        }

        public static void CautaComandaDupaID(GestionareComenziRestaurant_FisierText adminComenzi, int idCautat)
        {
            ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out int nrComenzi);
            foreach (ComandaRestaurant comanda in comenzi)
            {
                if (comanda != null && comanda.IDComanda == idCautat)
                {
                    AfisareComanda(comanda);
                    return;
                }
            }
            Console.WriteLine("Comanda cu ID-ul specificat nu a fost gasita.");
        }

        public static void CautaComandaDupaIDMemorie(GestionareComenziRestaurant_Memorie adminComenziMemorie, int idCautat)
        {
            ComandaRestaurant[] comenzi = adminComenziMemorie.GetComenzi(out int nrComenzi);
            foreach (ComandaRestaurant comanda in comenzi)
            {
                if (comanda != null && comanda.IDComanda == idCautat)
                {
                    AfisareComanda(comanda);
                    return;
                }
            }
            Console.WriteLine("Comanda cu ID-ul specificat nu a fost gasita.");
        }

        
    }
}
