using System;
using System.Configuration;
using LibrarieModele;
using NivelStocareDate;
using RestaurantManagement.Models;

namespace FirmaRestaurant
{
    class Program
    {
        static void Main()
        {
            string numeFisierMenu = ConfigurationManager.AppSettings["NumeFisierMenus"];
            string numeFisierComenzi = ConfigurationManager.AppSettings["NumeFisierComenzi"];

            GestionareMenu_FisierText gestiuneFisierMenus = new GestionareMenu_FisierText(numeFisierMenu);
            GestionareMenu_Memorie gestiuneMemorieMenus = new GestionareMenu_Memorie();

            GestionareComenzi_FisierText gestiuneFisierComenzi = new GestionareComenzi_FisierText(numeFisierComenzi);
            GestionareComenzi_Memorie gestiuneMemorieComenzi = new GestionareComenzi_Memorie();

            Menu menuNou = null;
            Comanda comandaNoua = null;
            int nrMenus = 0;
            int nrComenzi = 0;

            string optiune;
            do
            {
                AfisareMeniu();
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        (menuNou, comandaNoua) = CitireComandaSiMenuTastatura();
                        break;

                    case "I":
                        AfisareMenuSiComanda(menuNou, comandaNoua);
                        break;

                    case "A":
                        var (menusFisier, nrMenusFisier) = gestiuneFisierMenus.GetMenus();
                        AfisareMenus(menusFisier, nrMenusFisier);
                        break;

                    case "M":
                        Menu[] menusMemorie = gestiuneMemorieMenus.GetMenus(out nrMenus);
                        AfisareMenus(menusMemorie, nrMenus);
                        break;

                    case "S":
                        gestiuneFisierMenus.AddMenu(menuNou);
                        break;

                    case "L":
                        gestiuneMemorieMenus.AddMenu(menuNou);
                        break;

                    case "F":
                        CautareMenu(gestiuneFisierMenus);
                        break;

                    case "N":
                        CautareMenu(gestiuneMemorieMenus);
                        break;

                    default:
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        private static void AfisareMeniu()
        {
            Console.WriteLine("\n--- Meniu Principal ---");
            Console.WriteLine("C. Citire informatii meniu si comanda de la tastatura");
            Console.WriteLine("I. Afisarea informatiilor despre ultimul meniu si comanda introduse");
            Console.WriteLine("A. Afisare meniuri din fisier");
            Console.WriteLine("M. Afisare meniuri din memorie");
            Console.WriteLine("S. Salvare meniu in fisier");
            Console.WriteLine("L. Salvare meniu in lista de meniuri");
            Console.WriteLine("F. Cautare meniu din fisier");
            Console.WriteLine("N. Cautare meniu din memorie");
            Console.WriteLine("X. Inchidere program");
            Console.Write("Alegeti o optiune: ");
        }

        public static (Menu, Comanda) CitireComandaSiMenuTastatura()
        {
            Console.WriteLine("\n--- Introducere date meniu ---");
            Console.Write("Introduceti ID meniu: ");
            int idMenu = int.Parse(Console.ReadLine());

            Console.Write("Introduceti felul principal: ");
            string mainCourse = Console.ReadLine();

            Console.Write("Introduceti garnitura: ");
            string sideDishes = Console.ReadLine();

            Console.Write("Introduceti bautura: ");
            string drink = Console.ReadLine();

            Console.Write("Introduceti desertul: ");
            string dessert = Console.ReadLine();

            Menu menu = new Menu(idMenu, mainCourse, sideDishes, drink, dessert);

            Console.WriteLine("\n--- Introducere date comanda ---");
            Console.Write("Introduceti ID comanda: ");
            int idComanda = int.Parse(Console.ReadLine());

            Console.Write("Introduceti numarul mesei (Masa1, Masa2, etc., Masa5): ");
            string nrMasaInput = Console.ReadLine();
            Enumerare.Mese nrMasa;
            while (!Enum.TryParse(nrMasaInput, out nrMasa))
            {
                Console.Write("Valoare invalida. Introduceti numarul mesei (Masa1, Masa2, etc.): ");
                nrMasaInput = Console.ReadLine();
            }

            Console.Write("Introduceti pretul total: ");
            double pretTotal = double.Parse(Console.ReadLine());

            Console.Write("Introduceti starea comenzii: ");
            string stareComanda = Console.ReadLine();

            Comanda comanda = new Comanda(idComanda, (int)nrMasa, pretTotal, stareComanda, menu, idMenu);

            return (menu, comanda);
        }

        public static void AfisareMenuSiComanda(Menu menu, Comanda comanda)
        {
            if (menu != null)
            {
                string infoMenu = string.Format("Meniu:\n" +
                                               "  ID: {0}\n" +
                                               "  Fel principal: {1}\n" +
                                               "  Garnitura: {2}\n" +
                                               "  Bautura: {3}\n" +
                                               "  Desert: {4}",
                                               menu.IDMenu,
                                               menu.MainCourse ?? "NECUNOSCUT",
                                               menu.SideDishes ?? "NECUNOSCUT",
                                               menu.Drink ?? "NECUNOSCUT",
                                               menu.Dessert ?? "NECUNOSCUT");

                Console.WriteLine(infoMenu);
            }
            else
            {
                Console.WriteLine("Nu exista niciun meniu de afisat.");
            }

            if (comanda != null)
            {
                string infoComanda = string.Format("Comanda:\n" +
                                                  "  ID: {0}\n" +
                                                  "  Numar masa: {1}\n" +
                                                  "  Pret total: {2}\n" +
                                                  "  Stare comanda: {3}\n" +
                                                  "  ID Meniu: {4}",
                                                  comanda.IDComanda,
                                                  comanda.NrMasa,
                                                  comanda.PretTotal,
                                                  comanda.StareComanda ?? "NECUNOSCUT",
                                                  comanda.IDMenu);
                Console.WriteLine(infoComanda);
            }
            else
            {
                Console.WriteLine("Nu exista nicio comanda de afisat.");
            }
        }

        public static void AfisareMenus(Menu[] menus, int nrMenus)
        {
            if (menus == null || nrMenus == 0)
            {
                Console.WriteLine("Nu exista meniuri de afisat.");
                return;
            }
            Console.WriteLine("\n--- Meniuri ---");
            for (int contor = 0; contor < nrMenus; contor++)
            {
                if (menus[contor] != null)
                    AfisareMenuSiComanda(menus[contor], null);
            }
        }

        public static void AfisareComenzi(Comanda[] comenzi, int nrComenzi)
        {
            if (comenzi == null || nrComenzi == 0)
            {
                Console.WriteLine("Nu exista comenzi de afisat.");
                return;
            }
            Console.WriteLine("\n--- Comenzi ---");
            for (int contor = 0; contor < nrComenzi; contor++)
            {
                if (comenzi[contor] != null)
                    AfisareMenuSiComanda(null, comenzi[contor]);
            }
        }

        private static void CautareMenu(dynamic gestiune)
        {
            string optiuneCautare;
            do
            {
                Console.WriteLine("\n--- Cautare Meniu ---");
                Console.WriteLine("Cautare dupa: ");
                Console.WriteLine("  1. ID meniu");
                Console.WriteLine("  2. Fel principal");
                Console.WriteLine("  X. Iesire");
                Console.Write("Alegeti o optiune: ");
                optiuneCautare = Console.ReadLine();

                switch (optiuneCautare)
                {
                    case "1":
                        Console.Write("Introduceti ID-ul meniului cautat: ");
                        if (int.TryParse(Console.ReadLine(), out int idMenu))
                        {
                            Menu menuCautat = gestiune.CautareDupaIDMenu(idMenu);
                            if (menuCautat != null)
                            {
                                Console.WriteLine("Meniul a fost gasit: ");
                                AfisareMenuSiComanda(menuCautat, null);
                            }
                            else
                            {
                                Console.WriteLine($"Meniul cu ID-ul {idMenu} nu a fost gasit.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID-ul introdus nu este valid.");
                        }
                        break;
                    case "2":
                        Console.Write("Introduceti felul principal cautat: ");
                        string mainCourse = Console.ReadLine();
                        Menu[] menusCautate = gestiune.CautareDupaFelPrincipal(mainCourse);
                        if (menusCautate != null && menusCautate.Length > 0)
                        {
                            Console.WriteLine("Meniurile au fost gasite: ");
                            AfisareMenus(menusCautate, menusCautate.Length);
                        }
                        else
                        {
                            Console.WriteLine($"Nu au fost gasite meniuri cu felul principal {mainCourse}");
                        }
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Optiune invalida");
                        break;
                }
            } while (optiuneCautare.ToUpper() != "X");
        }
    }
}
