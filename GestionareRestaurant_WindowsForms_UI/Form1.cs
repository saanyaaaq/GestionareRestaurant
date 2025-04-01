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

namespace GestionareRestaurant_WindowsForms_UI
{
    public partial class Form1 : Form
    {
        GestionareComenziRestaurant_FisierText adminComenzi;
        private Label lblIDComanda;
        private Label lblNrMasa;
        private Label lblPretTotal;
        private Label lblStareComanda;
        
        private Label lblFelPrincipal;
        private Label lblGarnituri;
        private Label lblBautura;
        private Label lblDesert;
        

        private Label[] lblsIDComanda;
        private Label[] lblsNrMasa;
        private Label[] lblsPretTotal;
        private Label[] lblsStareComanda;
        
        private Label[] lblsFelPrincipal;
        private Label[] lblsGarnituri;
        private Label[] lblsBautura;
        private Label[] lblsDesert;
       

        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 100;

        public Form1()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;
            adminComenzi = new GestionareComenziRestaurant_FisierText(caleCompletaFisier);
            int nrComenzi = 0;

            ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out nrComenzi);

            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Italic);
            this.ForeColor = Color.Maroon;
            this.Text = "Informatii comenzi";

            lblIDComanda = new Label();
            lblIDComanda.Width = LATIME_CONTROL;
            lblIDComanda.Text = "ID Comanda:";
            lblIDComanda.Left = DIMENSIUNE_PAS_X;
            lblIDComanda.ForeColor = Color.Red;
            this.Controls.Add(lblIDComanda);

            lblNrMasa = new Label();
            lblNrMasa.Width = LATIME_CONTROL;
            lblNrMasa.Text = "Nr Masa:";
            lblNrMasa.Left = 2 * DIMENSIUNE_PAS_X;
            lblNrMasa.ForeColor = Color.Red;
            this.Controls.Add(lblNrMasa);

            lblPretTotal = new Label();
            lblPretTotal.Width = LATIME_CONTROL;
            lblPretTotal.Text = "Pret Total:";
            lblPretTotal.Left = 3 * DIMENSIUNE_PAS_X;
            lblPretTotal.ForeColor = Color.Red;
            this.Controls.Add(lblPretTotal);

            lblStareComanda = new Label();
            lblStareComanda.Width = LATIME_CONTROL;
            lblStareComanda.Text = "Stare Comanda:";
            lblStareComanda.Left = 4 * DIMENSIUNE_PAS_X;
            lblStareComanda.ForeColor = Color.Red;
            this.Controls.Add(lblStareComanda);

            

            lblFelPrincipal = new Label();
            lblFelPrincipal.Width = LATIME_CONTROL;
            lblFelPrincipal.Text = "Fel Principal:";
            lblFelPrincipal.Left = 6 * DIMENSIUNE_PAS_X;
            lblFelPrincipal.ForeColor = Color.Red;
            this.Controls.Add(lblFelPrincipal);

            lblGarnituri = new Label();
            lblGarnituri.Width = LATIME_CONTROL;
            lblGarnituri.Text = "Garnituri:";
            lblGarnituri.Left = 7 * DIMENSIUNE_PAS_X;
            lblGarnituri.ForeColor = Color.Red;
            this.Controls.Add(lblGarnituri);

            lblBautura = new Label();
            lblBautura.Width = LATIME_CONTROL;
            lblBautura.Text = "Bautura:";
            lblBautura.Left = 8 * DIMENSIUNE_PAS_X;
            lblBautura.ForeColor = Color.Red;
            this.Controls.Add(lblBautura);

            lblDesert = new Label();
            lblDesert.Width = LATIME_CONTROL;
            lblDesert.Text = "Desert:";
            lblDesert.Left = 9 * DIMENSIUNE_PAS_X;
            lblDesert.ForeColor = Color.Red;
            this.Controls.Add(lblDesert);

        

            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaComenzi();
        }

        private void AfiseazaComenzi()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Label && this.Controls[i] != lblIDComanda &&
                    this.Controls[i] != lblNrMasa && this.Controls[i] != lblPretTotal &&
                    this.Controls[i] != lblStareComanda && this.Controls[i] != lblFelPrincipal && this.Controls[i] != lblGarnituri &&
                    this.Controls[i] != lblBautura && this.Controls[i] != lblDesert)
                   
                {
                    this.Controls.RemoveAt(i);
                }
            }

            ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out int nrComenzi);

            if (comenzi == null || comenzi.Length == 0)
            {
                MessageBox.Show("Nu există comenzi înregistrate.");
                return;
            }

            lblsIDComanda = new Label[nrComenzi];
            lblsNrMasa = new Label[nrComenzi];
            lblsPretTotal = new Label[nrComenzi];
            lblsStareComanda = new Label[nrComenzi];
            
            lblsFelPrincipal = new Label[nrComenzi];
            lblsGarnituri = new Label[nrComenzi];
            lblsBautura = new Label[nrComenzi];
            lblsDesert = new Label[nrComenzi];
            

            for (int i = 0; i < nrComenzi; i++)
            {
                lblsIDComanda[i] = new Label();
                lblsIDComanda[i].Width = LATIME_CONTROL;
                lblsIDComanda[i].Text = comenzi[i].IDComanda.ToString();
                lblsIDComanda[i].Left = DIMENSIUNE_PAS_X;
                lblsIDComanda[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsIDComanda[i]);

                lblsNrMasa[i] = new Label();
                lblsNrMasa[i].Width = LATIME_CONTROL;
                lblsNrMasa[i].Text = comenzi[i].NrMasa.ToString();
                lblsNrMasa[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsNrMasa[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsNrMasa[i]);

                lblsPretTotal[i] = new Label();
                lblsPretTotal[i].Width = LATIME_CONTROL;
                lblsPretTotal[i].Text = comenzi[i].PretTotal.ToString("F2");
                lblsPretTotal[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsPretTotal[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsPretTotal[i]);

                lblsStareComanda[i] = new Label();
                lblsStareComanda[i].Width = LATIME_CONTROL;
                lblsStareComanda[i].Text = comenzi[i].StareComanda;
                lblsStareComanda[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsStareComanda[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsStareComanda[i]);

                

                lblsFelPrincipal[i] = new Label();
                lblsFelPrincipal[i].Width = LATIME_CONTROL;
                lblsFelPrincipal[i].Text = comenzi[i].Menu.FelPrincipal;
                lblsFelPrincipal[i].Left = 6 * DIMENSIUNE_PAS_X;
                lblsFelPrincipal[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsFelPrincipal[i]);

                lblsGarnituri[i] = new Label();
                lblsGarnituri[i].Width = LATIME_CONTROL;
                lblsGarnituri[i].Text = comenzi[i].Menu.Garnituri;
                lblsGarnituri[i].Left = 7 * DIMENSIUNE_PAS_X;
                lblsGarnituri[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsGarnituri[i]);

                lblsBautura[i] = new Label();
                lblsBautura[i].Width = LATIME_CONTROL;
                lblsBautura[i].Text = comenzi[i].Menu.Bautura;
                lblsBautura[i].Left = 8 * DIMENSIUNE_PAS_X;
                lblsBautura[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsBautura[i]);

                lblsDesert[i] = new Label();
                lblsDesert[i].Width = LATIME_CONTROL;
                lblsDesert[i].Text = comenzi[i].Menu.Desert;
                lblsDesert[i].Left = 9 * DIMENSIUNE_PAS_X;
                lblsDesert[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(lblsDesert[i]);

                
            }
        }
    }
}

