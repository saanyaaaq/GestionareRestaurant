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
                Console.WriteLine("S. Salvare comanda in fisier");
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
                    case "S":
                        int idComanda = ++nrComenzi;
                        comandaNoua.IDComanda = idComanda;
                        // adaugare comanda in fisier
                        adminComenzi.AddComanda(comandaNoua);
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

            Console.Write("Introdu Numarul Mesei: ");
            int numarPersoane = int.Parse(Console.ReadLine());

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

            MenuRestaurant menu = new MenuRestaurant(felPrincipal, garnitura, bautura, desert);
            return new ComandaRestaurant(id, numarPersoane, pretTotal, status, menu);
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
    }
}

