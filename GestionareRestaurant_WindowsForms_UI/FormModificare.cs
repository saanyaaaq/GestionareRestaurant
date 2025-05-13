using NivelStocareDate;
using System;
using System.Collections;
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
using static LibrarieModele.Enumerare;


namespace GestionareRestaurant_WindowsForms_UI
{
    public partial class FormModificare : Form
    {
        private const int NR_MAX_CARACTERE = 15;
        GestionareComenziRestaurant_FisierText adminComenzi;

        ArrayList optiuniSelectate = new ArrayList();
        public FormModificare(int idComanda)
        {
            InitializeComponent();
            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            adminComenzi = new GestionareComenziRestaurant_FisierText(caleCompletaFisier);

            txtIDComanda.Text = idComanda.ToString();

            SetareControale();
        }
        private void SetareControale()
        {
            ComandaRestaurant comanda = adminComenzi.GetComanda(Int32.Parse(txtIDComanda.Text));

            if (comanda != null)
            {
                txtPretTotal.Text = comanda.PretTotal.ToString();
                txtStareComanda.Text = comanda.StareComanda;
                txtFelPrincipal.Text = comanda.Menu.FelPrincipal;
                txtGarnituri.Text = comanda.Menu.Garnituri;
                txtBautura.Text = comanda.Menu.Bautura;
                txtDesert.Text = comanda.Menu.Desert;
                foreach (var opt in gpbOptiuniComanda.Controls)
                {
                    if (opt is CheckBox)
                    {
                        var optiune = opt as CheckBox;
                        foreach (String dis in comanda.OptiuniMeniu)
                            if (optiune.Text == dis)
                            {
                                optiune.Checked = true;
                            }
                    }
                }
                switch (comanda.NrMasa)
                {
                    case Enumerare.Mese.Masa1:
                        rdbMasa1.Checked = true;
                        break;
                    case Enumerare.Mese.Masa2:
                        rdbMasa2.Checked = true;
                        break;
                    case Enumerare.Mese.Masa3:
                        rdbMasa3.Checked = true;
                        break;
                    case Enumerare.Mese.Masa4:
                        rdbMasa4.Checked = true;
                        break;
                    case Enumerare.Mese.Masa5:
                        rdbMasa5.Checked = true;
                        break;

                }




            }
        }


        private void CkbOptiuniComanda_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox;

            string optiuneSelectata = checkBoxControl.Text;

            if (checkBoxControl.Checked)
                optiuniSelectate.Add(optiuneSelectata);
            else
                optiuniSelectate.Remove(optiuneSelectata);
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
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


            // Преобразование данных
            int idComanda = int.Parse(txtIDComanda.Text);
            // Enumerare.Mese nrMasa = (Enumerare.Mese)Enum.Parse(typeof(Enumerare.Mese), txtNrMasa.Text);
            double pretTotal = double.Parse(txtPretTotal.Text);
            string stareComanda = txtStareComanda.Text;
            string felPrincipal = txtFelPrincipal.Text;
            string garnituri = txtGarnituri.Text;
            string bautura = txtBautura.Text;
            string desert = txtDesert.Text;

            ArrayList OptiuniComanda = new ArrayList();
            OptiuniComanda.AddRange(optiuniSelectate);
            Mese nrMasa = GetNrMasa();

            // Создание объектов
            MeniuRestaurant meniu = new MeniuRestaurant(felPrincipal, garnituri, bautura, desert);
            ComandaRestaurant comanda = new ComandaRestaurant(idComanda, nrMasa, pretTotal, stareComanda, meniu, OptiuniComanda);

            // Добавление заказа
            adminComenzi.UpdateComanda(comanda);

            MessageBox.Show("Comanda a fost Modificata cu succes!");

            // Очистка полей ввода
            txtIDComanda.Clear();

            txtPretTotal.Clear();
            txtStareComanda.Clear();
            txtFelPrincipal.Clear();
            txtGarnituri.Clear();
            txtBautura.Clear();
            txtDesert.Clear();
        }
    

    public bool Prevalidare()
        {
            bool hasErrors = false;

            if (string.IsNullOrWhiteSpace(txtIDComanda.Text))
            {
                lblEroareIDComanda.Text = "Camp gol!";
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
        private Mese GetNrMasa()
        {
            if (rdbMasa1?.Checked == true)
                return Mese.Masa1;
            if (rdbMasa2?.Checked == true)
                return Mese.Masa2;
            if (rdbMasa3?.Checked == true)
                return Mese.Masa3;
            if (rdbMasa4?.Checked == true)
                return Mese.Masa4;

            return Mese.Masa5; // Implicit, dacă niciun alt buton nu este selectat
        }
    }
}
