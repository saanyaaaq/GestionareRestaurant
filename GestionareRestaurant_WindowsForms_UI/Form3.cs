using NivelStocareDate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionareRestaurant_WindowsForms_UI
{
    public partial class Form3 : Form
    {
        GestionareComenziRestaurant_FisierText adminComenzi;
        public Form3()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminComenzi = new GestionareComenziRestaurant_FisierText(caleCompletaFisier);
        }

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIDComanda.Text) && int.TryParse(txtIDComanda.Text, out int idComanda))
            {
                ComandaRestaurant comandaGasita = adminComenzi.GetComanda(idComanda);

                if (comandaGasita != null)
                {
                    MessageBox.Show(comandaGasita.Info(), "Comanda gasita");
                }
                else
                {
                    MessageBox.Show("Comanda cu ID-ul specificat nu a fost gasita.");
                }
            }
            else
            {
                MessageBox.Show("Introduceti un ID valid:");
            }
        }

    }
}

