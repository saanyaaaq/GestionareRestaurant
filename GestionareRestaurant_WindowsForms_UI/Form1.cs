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
using LibrarieModele;
using NivelStocareDate;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GestionareRestaurant_WindowsForms_UI
{
    public partial class Form1 : Form
    {
        GestionareComenziRestaurant_FisierText adminComenzi;
       
        private const int LATIME_CONTROL = 150;
        private const int DIMENSIUNE_PAS_Y = 40;
        private const int DIMENSIUNE_PAS_X = 160;

        public Form1()
        {
            InitializeComponent();

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminComenzi = new GestionareComenziRestaurant_FisierText(caleCompletaFisier);

            int yInputStart = 105;

            //setare proprietati
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Italic);
            this.ForeColor = Color.Navy;
            this.Text = "Informatii comenzi restaurant";
        

            this.Load += Form1_Load;
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaComenzi();
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            AfiseazaComenzi();
        }
        private void AfiseazaComenzi()
        {
            // Получение массива заказов
            ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out int nrComenzi);

            // Создание массива меток для отображения данных
            Label[,] lblsComenzi = new Label[nrComenzi, 8];

            for (int i = 0; i < nrComenzi; i++)
            {
                ComandaRestaurant comanda = comenzi[i];

                // IDComanda
                lblsComenzi[i, 0] = new Label();
                lblsComenzi[i, 0].Width = LATIME_CONTROL;
                lblsComenzi[i, 0].Text = comanda.IDComanda.ToString();
                lblsComenzi[i, 0].Left = DIMENSIUNE_PAS_X;
                lblsComenzi[i, 0].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 0]);

                // NrMasa
                lblsComenzi[i, 1] = new Label();
                lblsComenzi[i, 1].Width = LATIME_CONTROL;
                lblsComenzi[i, 1].Text = comanda.NrMasa.ToString();
                lblsComenzi[i, 1].Left = 2 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 1].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 1]);

                // PretTotal
                lblsComenzi[i, 2] = new Label();
                lblsComenzi[i, 2].Width = LATIME_CONTROL;
                lblsComenzi[i, 2].Text = comanda.PretTotal.ToString("F2");
                lblsComenzi[i, 2].Left = 3 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 2].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 2]);

                // StareComanda
                lblsComenzi[i, 3] = new Label();
                lblsComenzi[i, 3].Width = LATIME_CONTROL;
                lblsComenzi[i, 3].Text = comanda.StareComanda;
                lblsComenzi[i, 3].Left = 4 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 3].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 3]);

                // FelPrincipal
                lblsComenzi[i, 4] = new Label();
                lblsComenzi[i, 4].Width = LATIME_CONTROL;
                lblsComenzi[i, 4].Text = comanda.Menu.FelPrincipal;
                lblsComenzi[i, 4].Left = 5 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 4].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 4]);

                // Garnitura
                lblsComenzi[i, 5] = new Label();
                lblsComenzi[i, 5].Width = LATIME_CONTROL;
                lblsComenzi[i, 5].Text = comanda.Menu.Garnituri;
                lblsComenzi[i, 5].Left = 6 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 5].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 5]);

                // Bautura
                lblsComenzi[i, 6] = new Label();
                lblsComenzi[i, 6].Width = LATIME_CONTROL;
                lblsComenzi[i, 6].Text = comanda.Menu.Bautura;
                lblsComenzi[i, 6].Left = 7 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 6].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 6]);

                // Desert
                lblsComenzi[i, 7] = new Label();
                lblsComenzi[i, 7].Width = LATIME_CONTROL;
                lblsComenzi[i, 7].Text = comanda.Menu.Desert;
                lblsComenzi[i, 7].Left = 8 * DIMENSIUNE_PAS_X;
                lblsComenzi[i, 7].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsComenzi[i, 7]);
            }
        }

        private void buttonCautare_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

       
    }
}

