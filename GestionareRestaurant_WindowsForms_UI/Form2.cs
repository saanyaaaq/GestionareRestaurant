using LibrarieModele;
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

    public partial class Form2: Form
    {
        private const int NR_MAX_CARACTERE = 15;
        GestionareComenziRestaurant_FisierText adminComenzi;
        public Form2()
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminComenzi = new GestionareComenziRestaurant_FisierText(caleCompletaFisier);
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            // Сброс текста ошибок
            lblEroareIDComanda.Text = "";
            lblEroareNrMasa.Text = "";
            lblEroarePretTotal.Text = "";
            lblEroareStareComanda.Text = "";
            lblEroareFelPrincipal.Text = "";
            lblEroareGarnituri.Text = "";
            lblEroareBautura.Text = "";
            lblEroareDesert.Text = "";

            // Проверка на ошибки
            if (Prevalidare() || Validare())
            {
                // Если есть ошибки, выходим из метода
                return;
            }

            try
            {
                // Преобразование данных
                int idComanda = int.Parse(txtIDComanda.Text);
                Enumerare.Mese nrMasa = (Enumerare.Mese)Enum.Parse(typeof(Enumerare.Mese), txtNrMasa.Text);
                double pretTotal = double.Parse(txtPretTotal.Text);
                string stareComanda = txtStareComanda.Text;
                string felPrincipal = txtFelPrincipal.Text;
                string garnituri = txtGarnituri.Text;
                string bautura = txtBautura.Text;
                string desert = txtDesert.Text;

                // Создание объектов
                MeniuRestaurant meniu = new MeniuRestaurant(felPrincipal, garnituri, bautura, desert);
                ComandaRestaurant comanda = new ComandaRestaurant(idComanda, nrMasa, pretTotal, stareComanda, meniu);

                // Добавление заказа
                adminComenzi.AddComanda(comanda);

                MessageBox.Show("Comanda a fost adăugată cu succes!");

                // Очистка полей ввода
                txtIDComanda.Clear();
                txtNrMasa.Clear();
                txtPretTotal.Clear();
                txtStareComanda.Clear();
                txtFelPrincipal.Clear();
                txtGarnituri.Clear();
                txtBautura.Clear();
                txtDesert.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }
        public bool Prevalidare()
        {
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(txtIDComanda.Text))
            {
                lblEroareIDComanda.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtNrMasa.Text))
            {
                lblEroareNrMasa.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtPretTotal.Text))
            {
                lblEroarePretTotal.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtStareComanda.Text))
            {
                lblEroareStareComanda.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtFelPrincipal.Text))
            {
                lblEroareFelPrincipal.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtGarnituri.Text))
            {
                lblEroareGarnituri.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtBautura.Text))
            {
                lblEroareBautura.Text = "Camp gol!";
                hasErrors = true;
            }

            if (string.IsNullOrWhiteSpace(txtDesert.Text))
            {
                lblEroareDesert.Text = "Camp gol!";
                hasErrors = true;
            }

            return hasErrors;
        }

        public bool Validare()
        {
            bool hasErrors = false;

            if (!int.TryParse(txtIDComanda.Text, out _))
            {
                lblEroareIDComanda.Text = "Trebuie sa fie un numar intreg!";
                hasErrors = true;
            }

            if (!Enum.TryParse<Enumerare.Mese>(txtNrMasa.Text, out _))
            {
                lblEroareNrMasa.Text = "Valoare invalida pentru masa!";
                hasErrors = true;
            }

            if (!double.TryParse(txtPretTotal.Text, out _))
            {
                lblEroarePretTotal.Text = "Trebuie sa fie un numar real!";
                hasErrors = true;
            }

            if (txtStareComanda.Text.Length > NR_MAX_CARACTERE)
            {
                lblEroareStareComanda.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtFelPrincipal.Text.Length > NR_MAX_CARACTERE)
            {
                lblEroareFelPrincipal.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtGarnituri.Text.Length > NR_MAX_CARACTERE)
            {
                lblEroareGarnituri.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtBautura.Text.Length > NR_MAX_CARACTERE)
            {
                lblEroareBautura.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            if (txtDesert.Text.Length > NR_MAX_CARACTERE)
            {
                lblEroareDesert.Text = $"Nr. max > {NR_MAX_CARACTERE} caractere!";
                hasErrors = true;
            }

            return hasErrors;
        }
        private void buttonSalveaza_Click(object sender, EventArgs e)
        {
            // Сброс текста ошибок
            lblEroareIDComanda.Text = "";
            lblEroareNrMasa.Text = "";
            lblEroarePretTotal.Text = "";
            lblEroareStareComanda.Text = "";
            lblEroareFelPrincipal.Text = "";
            lblEroareGarnituri.Text = "";
            lblEroareBautura.Text = "";
            lblEroareDesert.Text = "";

            // Проверка на ошибки
            bool areEroriPrevalidare = Prevalidare();
            bool areEroriValidare = Validare();

            // Если есть ошибки, выходим из метода
            if (areEroriPrevalidare || areEroriValidare)
            {
                return;
            }

            // Если ошибок нет, создаем и сохраняем заказ
            try
            {
                int idComanda = int.Parse(txtIDComanda.Text);
                Enumerare.Mese nrMasa = (Enumerare.Mese)Enum.Parse(typeof(Enumerare.Mese), txtNrMasa.Text);
                double pretTotal = double.Parse(txtPretTotal.Text);
                string stareComanda = txtStareComanda.Text;
                string felPrincipal = txtFelPrincipal.Text;
                string garnituri = txtGarnituri.Text;
                string bautura = txtBautura.Text;
                string desert = txtDesert.Text;

                // Создаем объекты
                MeniuRestaurant meniu = new MeniuRestaurant(felPrincipal, garnituri, bautura, desert);
                ComandaRestaurant comanda = new ComandaRestaurant(idComanda, nrMasa, pretTotal, stareComanda, meniu);

                // Сохраняем заказ
                adminComenzi.AddComanda(comanda);

                MessageBox.Show("Comanda a fost salvată cu succes!");

                // Очистка полей ввода
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare: {ex.Message}");
            }
        }

        private void ClearTextBoxes()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = string.Empty;
                }
            }
        }
    }
}
