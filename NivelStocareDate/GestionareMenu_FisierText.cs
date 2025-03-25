using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class GestionareMenu_FisierText
    {
        private const int NR_MAX_MENUS = 100;
        private string numeFisierMenu;

        public GestionareMenu_FisierText(string numeFisierMenu)
        {
            this.numeFisierMenu = numeFisierMenu;
            Stream streamFisier = File.Open(numeFisierMenu, FileMode.OpenOrCreate);
            streamFisier.Close();
        }

        public void AddMenu(Menu menu)
        {
            using (StreamWriter streamWriter = new StreamWriter(numeFisierMenu, true))
            {
                streamWriter.WriteLine(menu.ConversieLaSir_PentruFisier());
            }
        }

        public (Menu[] menus, int nrMenus) GetMenus()
        {
            Menu[] menus = new Menu[NR_MAX_MENUS];
            int nrMenus = 0;
            using (StreamReader streamReader = new StreamReader(numeFisierMenu))
            {
                string linieFisier;
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    menus[nrMenus++] = new Menu(linieFisier);
                }
            }
            return (menus, nrMenus);
        }

        public Menu CautareDupaIDMenu(int idMenu)
        {
            var (menus, nrMenus) = GetMenus();
            foreach (var menu in menus)
            {
                if (menu != null && menu.IDMenu == idMenu)
                {
                    return menu;
                }
            }
            return null;
        }
    }
}
