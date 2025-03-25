using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelStocareDate
{
    public class GestionareMenu_Memorie
    {
        private const int NR_MAX_MENUS = 100;
        private Menu[] menus;
        private int nrMenus;

        public GestionareMenu_Memorie()
        {
            menus = new Menu[NR_MAX_MENUS];
            nrMenus = 0;
        }

        public void AddMenu(Menu menu)
        {
            if (nrMenus < NR_MAX_MENUS)
            {
                menus[nrMenus] = menu;
                nrMenus++;
            }
            else
            {
                throw new InvalidOperationException("Numărul maxim de meniuri a fost atins.");
            }
        }

        public Menu[] GetMenus(out int nrMenus)
        {
            nrMenus = this.nrMenus;
            return menus.Take(nrMenus).ToArray();
        }

        public Menu CautareDupaIDMenu(int idMenu)
        {
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
