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
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Location = new Point(100, 100);
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.ForeColor = Color.FromArgb(64, 64, 64);
            this.Text = "Gestionare Comenzi Restaurant";
            this.BackColor = Color.WhiteSmoke;

            // Constants for layout
            const int MARGIN_LEFT = 50;
            const int MARGIN_TOP = 50;
            const int LABEL_WIDTH = 150;
            const int TEXTBOX_WIDTH = 250;
            const int ERROR_LABEL_WIDTH = 200;
            const int VERTICAL_SPACING = 45;
            const int HORIZONTAL_SPACING = 30;
            const int COLUMN_SPACING = 100;

            int yInputStart = MARGIN_TOP + 20;

            // Prima coloană - Stânga
            //adaugare control de tip Label pentru 'IDComanda';
            lblIDComanda = new Label();
            lblIDComanda.Text = "ID Comandă:";
            lblIDComanda.Left = MARGIN_LEFT;
            lblIDComanda.Top = yInputStart;
            lblIDComanda.Width = LABEL_WIDTH;
            lblIDComanda.ForeColor = Color.FromArgb(0, 102, 204);
            lblIDComanda.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblIDComanda);

            txtIDComanda = new TextBox();
            txtIDComanda.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtIDComanda.Top = yInputStart;
            txtIDComanda.Width = TEXTBOX_WIDTH;
            txtIDComanda.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtIDComanda);

            eroareIDComanda = new Label();
            eroareIDComanda.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareIDComanda.Top = yInputStart;
            eroareIDComanda.Width = ERROR_LABEL_WIDTH;
            eroareIDComanda.ForeColor = Color.Red;
            eroareIDComanda.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareIDComanda);

            //adaugare control de tip Label pentru 'NrMasa';
            lblNrMasa = new Label();
            lblNrMasa.Text = "Număr Masă:";
            lblNrMasa.Left = MARGIN_LEFT;
            lblNrMasa.Top = yInputStart + VERTICAL_SPACING;
            lblNrMasa.Width = LABEL_WIDTH;
            lblNrMasa.ForeColor = Color.FromArgb(0, 102, 204);
            lblNrMasa.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblNrMasa);

            txtNrMasa = new TextBox();
            txtNrMasa.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtNrMasa.Top = yInputStart + VERTICAL_SPACING;
            txtNrMasa.Width = TEXTBOX_WIDTH;
            txtNrMasa.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtNrMasa);

            eroareNrMasa = new Label();
            eroareNrMasa.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareNrMasa.Top = yInputStart + VERTICAL_SPACING;
            eroareNrMasa.Width = ERROR_LABEL_WIDTH;
            eroareNrMasa.ForeColor = Color.Red;
            eroareNrMasa.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareNrMasa);

            //adaugare control de tip Label pentru 'PretTotal';
            lblPretTotal = new Label();
            lblPretTotal.Text = "Preț Total:";
            lblPretTotal.Left = MARGIN_LEFT;
            lblPretTotal.Top = yInputStart + (2 * VERTICAL_SPACING);
            lblPretTotal.Width = LABEL_WIDTH;
            lblPretTotal.ForeColor = Color.FromArgb(0, 102, 204);
            lblPretTotal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblPretTotal);

            txtPretTotal = new TextBox();
            txtPretTotal.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtPretTotal.Top = yInputStart + (2 * VERTICAL_SPACING);
            txtPretTotal.Width = TEXTBOX_WIDTH;
            txtPretTotal.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtPretTotal);

            eroarePretTotal = new Label();
            eroarePretTotal.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroarePretTotal.Top = yInputStart + (2 * VERTICAL_SPACING);
            eroarePretTotal.Width = ERROR_LABEL_WIDTH;
            eroarePretTotal.ForeColor = Color.Red;
            eroarePretTotal.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroarePretTotal);

            //adaugare control de tip Label pentru 'StareComanda';
            lblStareComanda = new Label();
            lblStareComanda.Text = "Stare Comandă:";
            lblStareComanda.Left = MARGIN_LEFT;
            lblStareComanda.Top = yInputStart + (3 * VERTICAL_SPACING);
            lblStareComanda.Width = LABEL_WIDTH;
            lblStareComanda.ForeColor = Color.FromArgb(0, 102, 204);
            lblStareComanda.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblStareComanda);

            txtStareComanda = new TextBox();
            txtStareComanda.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtStareComanda.Top = yInputStart + (3 * VERTICAL_SPACING);
            txtStareComanda.Width = TEXTBOX_WIDTH;
            txtStareComanda.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtStareComanda);

            eroareStareComanda = new Label();
            eroareStareComanda.Left = MARGIN_LEFT + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareStareComanda.Top = yInputStart + (3 * VERTICAL_SPACING);
            eroareStareComanda.Width = ERROR_LABEL_WIDTH;
            eroareStareComanda.ForeColor = Color.Red;
            eroareStareComanda.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareStareComanda);

            // A doua coloană - Dreapta
            int rightColumnStart = this.Width / 2 + COLUMN_SPACING;

            //adaugare control de tip Label pentru 'FelPrincipal';
            lblFelPrincipal = new Label();
            lblFelPrincipal.Text = "Fel Principal:";
            lblFelPrincipal.Left = rightColumnStart;
            lblFelPrincipal.Top = yInputStart;
            lblFelPrincipal.Width = LABEL_WIDTH;
            lblFelPrincipal.ForeColor = Color.FromArgb(0, 102, 204);
            lblFelPrincipal.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblFelPrincipal);

            txtFelPrincipal = new TextBox();
            txtFelPrincipal.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtFelPrincipal.Top = yInputStart;
            txtFelPrincipal.Width = TEXTBOX_WIDTH;
            txtFelPrincipal.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtFelPrincipal);

            eroareFelPrincipal = new Label();
            eroareFelPrincipal.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareFelPrincipal.Top = yInputStart;
            eroareFelPrincipal.Width = ERROR_LABEL_WIDTH;
            eroareFelPrincipal.ForeColor = Color.Red;
            eroareFelPrincipal.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareFelPrincipal);

            //adaugare control de tip Label pentru 'Garnituri';
            lblGarnituri = new Label();
            lblGarnituri.Text = "Garnituri:";
            lblGarnituri.Left = rightColumnStart;
            lblGarnituri.Top = yInputStart + VERTICAL_SPACING;
            lblGarnituri.Width = LABEL_WIDTH;
            lblGarnituri.ForeColor = Color.FromArgb(0, 102, 204);
            lblGarnituri.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblGarnituri);

            txtGarnituri = new TextBox();
            txtGarnituri.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtGarnituri.Top = yInputStart + VERTICAL_SPACING;
            txtGarnituri.Width = TEXTBOX_WIDTH;
            txtGarnituri.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtGarnituri);

            eroareGarnituri = new Label();
            eroareGarnituri.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareGarnituri.Top = yInputStart + VERTICAL_SPACING;
            eroareGarnituri.Width = ERROR_LABEL_WIDTH;
            eroareGarnituri.ForeColor = Color.Red;
            eroareGarnituri.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareGarnituri);

            //adaugare control de tip Label pentru 'Bautura';
            lblBautura = new Label();
            lblBautura.Text = "Băutură:";
            lblBautura.Left = rightColumnStart;
            lblBautura.Top = yInputStart + (2 * VERTICAL_SPACING);
            lblBautura.Width = LABEL_WIDTH;
            lblBautura.ForeColor = Color.FromArgb(0, 102, 204);
            lblBautura.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblBautura);

            txtBautura = new TextBox();
            txtBautura.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtBautura.Top = yInputStart + (2 * VERTICAL_SPACING);
            txtBautura.Width = TEXTBOX_WIDTH;
            txtBautura.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtBautura);

            eroareBautura = new Label();
            eroareBautura.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareBautura.Top = yInputStart + (2 * VERTICAL_SPACING);
            eroareBautura.Width = ERROR_LABEL_WIDTH;
            eroareBautura.ForeColor = Color.Red;
            eroareBautura.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareBautura);

            //adaugare control de tip Label pentru 'Desert';
            lblDesert = new Label();
            lblDesert.Text = "Desert:";
            lblDesert.Left = rightColumnStart;
            lblDesert.Top = yInputStart + (3 * VERTICAL_SPACING);
            lblDesert.Width = LABEL_WIDTH;
            lblDesert.ForeColor = Color.FromArgb(0, 102, 204);
            lblDesert.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.Controls.Add(lblDesert);

            txtDesert = new TextBox();
            txtDesert.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING;
            txtDesert.Top = yInputStart + (3 * VERTICAL_SPACING);
            txtDesert.Width = TEXTBOX_WIDTH;
            txtDesert.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Controls.Add(txtDesert);

            eroareDesert = new Label();
            eroareDesert.Left = rightColumnStart + LABEL_WIDTH + HORIZONTAL_SPACING + TEXTBOX_WIDTH + HORIZONTAL_SPACING;
            eroareDesert.Top = yInputStart + (3 * VERTICAL_SPACING);
            eroareDesert.Width = ERROR_LABEL_WIDTH;
            eroareDesert.ForeColor = Color.Red;
            eroareDesert.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            this.Controls.Add(eroareDesert);

            // Butoane
            Button btnAdauga = new Button();
            btnAdauga.Text = "Adaugă Comandă";
            btnAdauga.Left = MARGIN_LEFT;
            btnAdauga.Top = yInputStart + (4 * VERTICAL_SPACING);
            btnAdauga.Width = 180;
            btnAdauga.Height = 40;
            btnAdauga.BackColor = Color.FromArgb(0, 102, 204);
            btnAdauga.ForeColor = Color.White;
            btnAdauga.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAdauga.FlatStyle = FlatStyle.Flat;
            btnAdauga.Click += OnButtonAdaugaClicked;
            this.Controls.Add(btnAdauga);

            Button btnReseteaza = new Button();
            btnReseteaza.Text = "Resetează Lista";
            btnReseteaza.Left = MARGIN_LEFT + 200;
            btnReseteaza.Top = yInputStart + (4 * VERTICAL_SPACING);
            btnReseteaza.Width = 180;
            btnReseteaza.Height = 40;
            btnReseteaza.BackColor = Color.FromArgb(192, 192, 192);
            btnReseteaza.ForeColor = Color.White;
            btnReseteaza.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReseteaza.FlatStyle = FlatStyle.Flat;
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

            // Adăugare headers
            Label headerIDComanda = new Label();
            headerIDComanda.Text = "ID Comandă";
            headerIDComanda.Font = new Font("Arial", 10, FontStyle.Bold);
            headerIDComanda.Left = DIMENSIUNE_PAS_X;
            headerIDComanda.Top = 220;
            headerIDComanda.Width = LATIME_CONTROL;
            this.Controls.Add(headerIDComanda);

            Label headerNrMasa = new Label();
            headerNrMasa.Text = "Nr Masă";
            headerNrMasa.Font = new Font("Arial", 10, FontStyle.Bold);
            headerNrMasa.Left = 2 * DIMENSIUNE_PAS_X;
            headerNrMasa.Top = 220;
            headerNrMasa.Width = LATIME_CONTROL;
            this.Controls.Add(headerNrMasa);

            Label headerPretTotal = new Label();
            headerPretTotal.Text = "Preț Total";
            headerPretTotal.Font = new Font("Arial", 10, FontStyle.Bold);
            headerPretTotal.Left = 3 * DIMENSIUNE_PAS_X;
            headerPretTotal.Top = 220;
            headerPretTotal.Width = LATIME_CONTROL;
            this.Controls.Add(headerPretTotal);

            Label headerStareComanda = new Label();
            headerStareComanda.Text = "Stare Comandă";
            headerStareComanda.Font = new Font("Arial", 10, FontStyle.Bold);
            headerStareComanda.Left = 4 * DIMENSIUNE_PAS_X;
            headerStareComanda.Top = 220;
            headerStareComanda.Width = LATIME_CONTROL;
            this.Controls.Add(headerStareComanda);

            Label headerFelPrincipal = new Label();
            headerFelPrincipal.Text = "Fel Principal";
            headerFelPrincipal.Font = new Font("Arial", 10, FontStyle.Bold);
            headerFelPrincipal.Left = 5 * DIMENSIUNE_PAS_X;
            headerFelPrincipal.Top = 220;
            headerFelPrincipal.Width = LATIME_CONTROL;
            this.Controls.Add(headerFelPrincipal);

            Label headerGarnituri = new Label();
            headerGarnituri.Text = "Garnituri";
            headerGarnituri.Font = new Font("Arial", 10, FontStyle.Bold);
            headerGarnituri.Left = 6 * DIMENSIUNE_PAS_X;
            headerGarnituri.Top = 220;
            headerGarnituri.Width = LATIME_CONTROL;
            this.Controls.Add(headerGarnituri);

            Label headerBautura = new Label();
            headerBautura.Text = "Băutură";
            headerBautura.Font = new Font("Arial", 10, FontStyle.Bold);
            headerBautura.Left = 7 * DIMENSIUNE_PAS_X;
            headerBautura.Top = 220;
            headerBautura.Width = LATIME_CONTROL;
            this.Controls.Add(headerBautura);

            Label headerDesert = new Label();
            headerDesert.Text = "Desert";
            headerDesert.Font = new Font("Arial", 10, FontStyle.Bold);
            headerDesert.Left = 8 * DIMENSIUNE_PAS_X;
            headerDesert.Top = 220;
            headerDesert.Width = LATIME_CONTROL;
            this.Controls.Add(headerDesert);

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

