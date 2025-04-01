using LibrarieModele;
using System;

public class ComandaRestaurant
{
    private const char SEPARATOR_PRINCIPAL_FISIER = ';';
    private const int ID_COMANDA = 0;
    private const int NR_MASA = 1;
    private const int PRET_TOTAL = 2;
    private const int STARE_COMANDA = 3;
    private const int DESCRIERE_MENIU = 4;
    public int IDComanda { get; set; }
    public Enumerare.Mese NrMasa { get; set; }
    public double PretTotal { get; set; }
    public string StareComanda { get; set; }
    public MeniuRestaurant Menu { get; set; }

    public ComandaRestaurant() { }

    public ComandaRestaurant(int idComanda, Enumerare.Mese nrMasa, double pretTotal, string stareComanda, MeniuRestaurant menu)
    {
        IDComanda = idComanda;
        NrMasa = nrMasa;
        PretTotal = pretTotal;
        StareComanda = stareComanda;
        Menu = menu;
    }

    public ComandaRestaurant(string linieFisier)
    {
        var date = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
        IDComanda = Convert.ToInt32(date[ID_COMANDA]);
        NrMasa = (Enumerare.Mese)Enum.Parse(typeof(Enumerare.Mese), date[NR_MASA]);
        PretTotal = Convert.ToDouble(date[PRET_TOTAL]);
        StareComanda = date[STARE_COMANDA];
        Menu = new MeniuRestaurant(date[DESCRIERE_MENIU]);
    }

    public string Info()
    {
        return $"Comanda cu id-ul #{IDComanda} pentru masa #{NrMasa} are pretul total: {PretTotal} si starea: {StareComanda}. Meniu: {Menu.Info()}";
    }

    public string ConversieLaSir_PentruFisier()
    {
        return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
            SEPARATOR_PRINCIPAL_FISIER,
            IDComanda,
            NrMasa,
            PretTotal,
            StareComanda,
            Menu.Descriere);
    }
}

