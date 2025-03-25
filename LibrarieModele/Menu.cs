using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Menu
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int ID_MENU = 0;
        private const int MAIN_COURSE = 1;
        private const int SIDE_DISHES = 2;
        private const int DRINK = 3;
        private const int DESSERT = 4;

        public int IDMenu { get; set; }
        public string MainCourse { get; set; }
        public string SideDishes { get; set; }
        public string Drink { get; set; }
        public string Dessert { get; set; }

        public Menu() { }

        public Menu(int idMenu, string mainCourse, string sideDishes, string drink, string dessert)
        {
            IDMenu = idMenu;
            MainCourse = mainCourse;
            SideDishes = sideDishes;
            Drink = drink;
            Dessert = dessert;
        }

        public Menu(string linieFisier)
        {
            var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            IDMenu = int.Parse(date[ID_MENU]);
            MainCourse = date[MAIN_COURSE];
            SideDishes = date[SIDE_DISHES];
            Drink = date[DRINK];
            Dessert = date[DESSERT];
        }

        public string Info()
        {
            return $"{IDMenu};{MainCourse};{SideDishes};{Drink};{Dessert}";
        }

        public string ConversieLaSir_PentruFisier()
        {
            return $"{IDMenu}{SEPARATOR_PRINCIPAL_FISIER}{MainCourse}{SEPARATOR_PRINCIPAL_FISIER}{SideDishes}{SEPARATOR_PRINCIPAL_FISIER}{Drink}{SEPARATOR_PRINCIPAL_FISIER}{Dessert}";
        }
    }
}
