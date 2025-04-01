public class MeniuRestaurant
{
    public string FelPrincipal { get; set; }
    public string Garnituri { get; set; }
    public string Bautura { get; set; }
    public string Desert { get; set; }
    public string Descriere { get; set; }

    // Constructor fara parametri
    public MeniuRestaurant()
    {
        FelPrincipal = string.Empty;
        Garnituri = string.Empty;
        Bautura = string.Empty;
        Desert = string.Empty;
        Descriere = string.Empty;
    }

    // Constructor cu parametri
    public MeniuRestaurant(string felPrincipal, string garnituri, string bautura, string desert)
    {
        this.FelPrincipal = felPrincipal;
        this.Garnituri = garnituri;
        this.Bautura = bautura;
        this.Desert = desert;
        this.Descriere = $"{felPrincipal}, {garnituri}, {bautura}, {desert}";
    }

    // Constructor care preia date dintr-o descriere
    public MeniuRestaurant(string descriere)
    {
        var parts = descriere.Split(',');
        if (parts.Length == 4)
        {
            FelPrincipal = parts[0].Trim();
            Garnituri = parts[1].Trim();
            Bautura = parts[2].Trim();
            Desert = parts[3].Trim();
        }
        else
        {
            FelPrincipal = string.Empty;
            Garnituri = string.Empty;
            Bautura = string.Empty;
            Desert = string.Empty;
        }
        Descriere = descriere;
    }

    // Metodă pentru obținerea informațiilor despre meniu
    public string Info()
    {
        return $"Fel Principal: {FelPrincipal}, Garnituri: {Garnituri}, Bautura: {Bautura}, Desert: {Desert}";
    }
}
