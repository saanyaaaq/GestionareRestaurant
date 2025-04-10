﻿using System;
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
        private const int NR_MAX_CARACTERE = 15;

        private Label lblIDComanda;
        private Label lblNrMasa;
        private Label lblPretTotal;
        private Label lblStareComanda;
        private Label lblFelPrincipal;
        private Label lblGarnituri;
        private Label lblBautura;
        private Label lblDesert;

        private Label eroareIDComanda;
        private Label eroareNrMasa;
        private Label eroarePretTotal;
        private Label eroareStareComanda;
        private Label eroareFelPrincipal;
        private Label eroareGarnituri;
        private Label eroareBautura;
        private Label eroareDesert;

        private TextBox txtIDComanda;
        private TextBox txtNrMasa;
        private TextBox txtPretTotal;
        private TextBox txtStareComanda;
        private TextBox txtFelPrincipal;
        private TextBox txtGarnituri;
        private TextBox txtBautura;
        private TextBox txtDesert;

        private Label[] lblsIDComanda;
        private Label[] lblsNrMasa;
        private Label[] lblsPretTotal;
        private Label[] lblsStareComanda;
        private Label[] lblsFelPrincipal;
        private Label[] lblsGarnituri;
        private Label[] lblsBautura;
        private Label[] lblsDesert;

        private Button buttonAdauga;
        private Button buttonRefresh;

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

            // Prima coloană - Stânga
            //adaugare control de tip Label pentru 'IDComanda';
            lblIDComanda = new Label();
            lblIDComanda.Text = "ID Comanda:";
            lblIDComanda.Left = 100;
            lblIDComanda.Top = yInputStart;
            lblIDComanda.ForeColor = Color.Navy;
            this.Controls.Add(lblIDComanda);

            txtIDComanda = new TextBox();
            txtIDComanda.Left = 200;
            txtIDComanda.Top = yInputStart;
            txtIDComanda.Width = 180;
            this.Controls.Add(txtIDComanda);

            eroareIDComanda = new Label();
            eroareIDComanda.Left = 340;
            eroareIDComanda.Top = yInputStart;
            eroareIDComanda.ForeColor = Color.Red;
            eroareIDComanda.AutoSize = true;
            this.Controls.Add(eroareIDComanda);

            //adaugare control de tip Label pentru 'NrMasa';
            lblNrMasa = new Label();
            lblNrMasa.Text = "Nr Masa:";
            lblNrMasa.Left = 100;
            lblNrMasa.Top = yInputStart + 30;
            lblNrMasa.ForeColor = Color.Navy;
            this.Controls.Add(lblNrMasa);

            txtNrMasa = new TextBox();
            txtNrMasa.Left = 200;
            txtNrMasa.Top = yInputStart + 30;
            txtNrMasa.Width = 180;
            this.Controls.Add(txtNrMasa);

            eroareNrMasa = new Label();
            eroareNrMasa.Left = 340;
            eroareNrMasa.Top = yInputStart + 30;
            eroareNrMasa.ForeColor = Color.Red;
            eroareNrMasa.AutoSize = true;
            this.Controls.Add(eroareNrMasa);

            //adaugare control de tip Label pentru 'PretTotal';
            lblPretTotal = new Label();
            lblPretTotal.Text = "Pret Total:";
            lblPretTotal.Left = 100;
            lblPretTotal.Top = yInputStart + 60;
            lblPretTotal.ForeColor = Color.Navy;
            this.Controls.Add(lblPretTotal);

            txtPretTotal = new TextBox();
            txtPretTotal.Left = 200;
            txtPretTotal.Top = yInputStart + 60;
            txtPretTotal.Width = 180;
            this.Controls.Add(txtPretTotal);

            eroarePretTotal = new Label();
            eroarePretTotal.Left = 340;
            eroarePretTotal.Top = yInputStart + 60;
            eroarePretTotal.ForeColor = Color.Red;
            eroarePretTotal.AutoSize = true;
            this.Controls.Add(eroarePretTotal);

            //adaugare control de tip Label pentru 'StareComanda';
            lblStareComanda = new Label();
            lblStareComanda.Text = "Stare Comanda:";
            lblStareComanda.Left = 100;
            lblStareComanda.Top = yInputStart + 90;
            lblStareComanda.ForeColor = Color.Navy;
            this.Controls.Add(lblStareComanda);

            txtStareComanda = new TextBox();
            txtStareComanda.Left = 200;
            txtStareComanda.Top = yInputStart + 90;
            txtStareComanda.Width = 180;
            this.Controls.Add(txtStareComanda);

            eroareStareComanda = new Label();
            eroareStareComanda.Left = 340;
            eroareStareComanda.Top = yInputStart + 90;
            eroareStareComanda.ForeColor = Color.Red;
            eroareStareComanda.AutoSize = true;
            this.Controls.Add(eroareStareComanda);

            // A doua coloană - Dreapta
            //adaugare control de tip Label pentru 'FelPrincipal';
            lblFelPrincipal = new Label();
            lblFelPrincipal.Text = "Fel Principal:";
            lblFelPrincipal.Left = 500;
            lblFelPrincipal.Top = yInputStart;
            lblFelPrincipal.ForeColor = Color.Navy;
            this.Controls.Add(lblFelPrincipal);

            txtFelPrincipal = new TextBox();
            txtFelPrincipal.Left = 600;
            txtFelPrincipal.Top = yInputStart;
            txtFelPrincipal.Width = 180;
            this.Controls.Add(txtFelPrincipal);

            eroareFelPrincipal = new Label();
            eroareFelPrincipal.Left = 740;
            eroareFelPrincipal.Top = yInputStart;
            eroareFelPrincipal.ForeColor = Color.Red;
            eroareFelPrincipal.AutoSize = true;
            this.Controls.Add(eroareFelPrincipal);

            //adaugare control de tip Label pentru 'Garnituri';
            lblGarnituri = new Label();
            lblGarnituri.Text = "Garnituri:";
            lblGarnituri.Left = 500;
            lblGarnituri.Top = yInputStart + 30;
            lblGarnituri.ForeColor = Color.Navy;
            this.Controls.Add(lblGarnituri);

            txtGarnituri = new TextBox();
            txtGarnituri.Left = 600;
            txtGarnituri.Top = yInputStart + 30;
            txtGarnituri.Width = 180;
            this.Controls.Add(txtGarnituri);

            eroareGarnituri = new Label();
            eroareGarnituri.Left = 740;
            eroareGarnituri.Top = yInputStart + 30;
            eroareGarnituri.ForeColor = Color.Red;
            eroareGarnituri.AutoSize = true;
            this.Controls.Add(eroareGarnituri);

            //adaugare control de tip Label pentru 'Bautura';
            lblBautura = new Label();
            lblBautura.Text = "Bautura:";
            lblBautura.Left = 500;
            lblBautura.Top = yInputStart + 60;
            lblBautura.ForeColor = Color.Navy;
            this.Controls.Add(lblBautura);

            txtBautura = new TextBox();
            txtBautura.Left = 600;
            txtBautura.Top = yInputStart + 60;
            txtBautura.Width = 180;
            this.Controls.Add(txtBautura);

            eroareBautura = new Label();
            eroareBautura.Left = 740;
            eroareBautura.Top = yInputStart + 60;
            eroareBautura.ForeColor = Color.Red;
            eroareBautura.AutoSize = true;
            this.Controls.Add(eroareBautura);

            //adaugare control de tip Label pentru 'Desert';
            lblDesert = new Label();
            lblDesert.Text = "Desert:";
            lblDesert.Left = 500;
            lblDesert.Top = yInputStart + 90;
            lblDesert.ForeColor = Color.Navy;
            this.Controls.Add(lblDesert);

            txtDesert = new TextBox();
            txtDesert.Left = 600;
            txtDesert.Top = yInputStart + 90;
            txtDesert.Width = 180;
            this.Controls.Add(txtDesert);

            eroareDesert = new Label();
            eroareDesert.Left = 740;
            eroareDesert.Top = yInputStart + 90;
            eroareDesert.ForeColor = Color.Red;
            eroareDesert.AutoSize = true;
            this.Controls.Add(eroareDesert);

            // Butoane
            Button btnAdauga = new Button();
            btnAdauga.Text = "Adaugă Comandă";
            btnAdauga.Left = 270;
            btnAdauga.Top = yInputStart + 130;
            btnAdauga.Width = 120;
            btnAdauga.Click += OnButtonAdaugaClicked;
            this.Controls.Add(btnAdauga);

            Button btnReseteaza = new Button();
            btnReseteaza.Text = "Resetează Lista";
            btnReseteaza.Left = 410;
            btnReseteaza.Top = yInputStart + 130;
            btnReseteaza.Width = 120;
            btnReseteaza.Click += OnButtonRefreshClicked;
            this.Controls.Add(btnReseteaza);

            this.Load += Form1_Load;
        }

        private void OnButtonAdaugaClicked(object sender, EventArgs e)
        {
            eroareIDComanda.Text = "";
            eroareNrMasa.Text = "";
            eroarePretTotal.Text = "";
            eroareStareComanda.Text = "";
            eroareFelPrincipal.Text = "";
            eroareGarnituri.Text = "";
            eroareBautura.Text = "";
            eroareDesert.Text = "";

            if (!Prevalidare() && !Validare())
            {
                int idComanda = int.Parse(txtIDComanda.Text);
                Enumerare.Mese nrMasa = (Enumerare.Mese)Enum.Parse(typeof(Enumerare.Mese), txtNrMasa.Text);
                double pretTotal = double.Parse(txtPretTotal.Text);
                string stareComanda = txtStareComanda.Text;
                string felPrincipal = txtFelPrincipal.Text;
                string garnituri = txtGarnituri.Text;
                string bautura = txtBautura.Text;
                string desert = txtDesert.Text;

                MeniuRestaurant meniu = new MeniuRestaurant(felPrincipal, garnituri, bautura, desert);
                ComandaRestaurant comanda = new ComandaRestaurant(idComanda, nrMasa, pretTotal, stareComanda, meniu);

                adminComenzi.AddComanda(comanda);

                MessageBox.Show("Comanda a fost adăugată cu succes!");

                // Resetează TextBox-urile după adăugare
                txtIDComanda.Clear();
                txtNrMasa.Clear();
                txtPretTotal.Clear();
                txtStareComanda.Clear();
                txtFelPrincipal.Clear();
                txtGarnituri.Clear();
                txtBautura.Clear();
                txtDesert.Clear();
            }
        }

        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            AfiseazaComenzi();
        }

        public bool Prevalidare()
        {
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(txtIDComanda.Text))
            {
                eroareIDComanda.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtNrMasa.Text))
            {
                eroareNrMasa.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtPretTotal.Text))
            {
                eroarePretTotal.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtStareComanda.Text))
            {
                eroareStareComanda.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtFelPrincipal.Text))
            {
                eroareFelPrincipal.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtGarnituri.Text))
            {
                eroareGarnituri.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtBautura.Text))
            {
                eroareBautura.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtDesert.Text))
            {
                eroareDesert.Text = "Camp gol!";
                hasErrors = true;
            }

            return hasErrors;
        }

        public bool Validare()
        {
            bool hasErrors = false;

            if (!int.TryParse(txtIDComanda.Text, out _))
            {
                eroareIDComanda.Text = "Trebuie sa fie un numar intreg!";
                hasErrors = true;
            }

            if (!Enum.TryParse<Enumerare.Mese>(txtNrMasa.Text, out _))
            {
                eroareNrMasa.Text = "Valoare invalida pentru masa!";
                hasErrors = true;
            }

            if (!double.TryParse(txtPretTotal.Text, out _))
            {
                eroarePretTotal.Text = "Trebuie sa fie un numar real!";
                hasErrors = true;
            }

            if (txtStareComanda.Text.Length > NR_MAX_CARACTERE)
            {
                eroareStareComanda.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtFelPrincipal.Text.Length > NR_MAX_CARACTERE)
            {
                eroareFelPrincipal.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtGarnituri.Text.Length > NR_MAX_CARACTERE)
            {
                eroareGarnituri.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtBautura.Text.Length > NR_MAX_CARACTERE)
            {
                eroareBautura.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtDesert.Text.Length > NR_MAX_CARACTERE)
            {
                eroareDesert.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            return hasErrors;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AfiseazaComenzi();
        }

        private void AfiseazaComenzi()
        {
            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is Label &&
                    this.Controls[i] != lblIDComanda &&
                    this.Controls[i] != lblNrMasa &&
                    this.Controls[i] != lblPretTotal &&
                    this.Controls[i] != lblStareComanda &&
                    this.Controls[i] != lblFelPrincipal &&
                    this.Controls[i] != lblGarnituri &&
                    this.Controls[i] != lblBautura &&
                    this.Controls[i] != lblDesert &&
                    this.Controls[i] != eroareIDComanda &&
                    this.Controls[i] != eroareNrMasa &&
                    this.Controls[i] != eroarePretTotal &&
                    this.Controls[i] != eroareStareComanda &&
                    this.Controls[i] != eroareFelPrincipal &&
                    this.Controls[i] != eroareGarnituri &&
                    this.Controls[i] != eroareBautura &&
                    this.Controls[i] != eroareDesert)
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
                lblsIDComanda[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsIDComanda[i]);

                lblsNrMasa[i] = new Label();
                lblsNrMasa[i].Width = LATIME_CONTROL;
                lblsNrMasa[i].Text = comenzi[i].NrMasa.ToString();
                lblsNrMasa[i].Left = 2 * DIMENSIUNE_PAS_X;
                lblsNrMasa[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsNrMasa[i]);

                lblsPretTotal[i] = new Label();
                lblsPretTotal[i].Width = LATIME_CONTROL;
                lblsPretTotal[i].Text = comenzi[i].PretTotal.ToString("F2");
                lblsPretTotal[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblsPretTotal[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsPretTotal[i]);

                lblsStareComanda[i] = new Label();
                lblsStareComanda[i].Width = LATIME_CONTROL;
                lblsStareComanda[i].Text = comenzi[i].StareComanda;
                lblsStareComanda[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblsStareComanda[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsStareComanda[i]);

                lblsFelPrincipal[i] = new Label();
                lblsFelPrincipal[i].Width = LATIME_CONTROL;
                lblsFelPrincipal[i].Text = comenzi[i].Menu.FelPrincipal;
                lblsFelPrincipal[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblsFelPrincipal[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsFelPrincipal[i]);

                lblsGarnituri[i] = new Label();
                lblsGarnituri[i].Width = LATIME_CONTROL;
                lblsGarnituri[i].Text = comenzi[i].Menu.Garnituri;
                lblsGarnituri[i].Left = 6 * DIMENSIUNE_PAS_X;
                lblsGarnituri[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsGarnituri[i]);

                lblsBautura[i] = new Label();
                lblsBautura[i].Width = LATIME_CONTROL;
                lblsBautura[i].Text = comenzi[i].Menu.Bautura;
                lblsBautura[i].Left = 7 * DIMENSIUNE_PAS_X;
                lblsBautura[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsBautura[i]);

                lblsDesert[i] = new Label();
                lblsDesert[i].Width = LATIME_CONTROL;
                lblsDesert[i].Text = comenzi[i].Menu.Desert;
                lblsDesert[i].Left = 8 * DIMENSIUNE_PAS_X;
                lblsDesert[i].Top = 250 + ((i + 1) * DIMENSIUNE_PAS_Y);
                this.Controls.Add(lblsDesert[i]);
            }
        }
    }
}

