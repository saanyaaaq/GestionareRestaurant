using System;
using System.CodeDom;
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
            
        }

        private void buttonAdauga_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out int nrComenzi);
            AfisareComenziInControlDataGridView();   
        }
  
        private void AfisareComenziInControlDataGridView()
        {
            dataGridComenzi.DataSource = null;

            ComandaRestaurant[] comenzi = adminComenzi.GetComenzi(out int nrComenzi);

            if (comenzi.Length == 0)
            {
                MessageBox.Show("Nu exista Comenzi in fisier!");
                return;
            }

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("ID Comanda");
            dataTable.Columns.Add("NrMasa");
            dataTable.Columns.Add("PretTotal");
            dataTable.Columns.Add("StareComanda");
            dataTable.Columns.Add("FelPrincipal");
            dataTable.Columns.Add("Garnituri");
            dataTable.Columns.Add("Bautura");
            dataTable.Columns.Add("Desert");
            dataTable.Columns.Add("OptiuniComanda");


            foreach (ComandaRestaurant comanda in comenzi )
            {
                DataRow row = dataTable.NewRow();
                if (comanda == null)
                    continue;
                row["ID Comanda"] = comanda.IDComanda;
                row["NrMasa"] = comanda.GetNrMasaText();
                row["PretTotal"] = comanda.PretTotal.ToString("F2");
                row["StareComanda"] = comanda.StareComanda;
                row["FelPrincipal"] = comanda.Menu.FelPrincipal;
                row["Garnituri"] = comanda.Menu.Garnituri;
                row["Bautura"] = comanda.Menu.Bautura;
                row["Desert"] = comanda.Menu.Desert;
                row["OptiuniComanda"] = comanda.OptiuniMeniuToString();
                dataTable.Rows.Add(row);
            }

            dataGridComenzi.DataSource = dataTable;
        }
        private void buttonCautare_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void buttonModifica_Click(object sender, EventArgs e)
        {
            if (dataGridComenzi.CurrentRow == null)
            {
                MessageBox.Show("Selectati o comanda pentru a o modifica.");
                return;
            }
            FormModificare form4 = new FormModificare(Convert.ToInt32(dataGridComenzi.CurrentRow.Cells[0].Value));
            form4.ShowDialog();
        }
    }
}

         

       
    


