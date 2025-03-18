public class MenuRestaurant
{
    public string MainCourse { get; set; }
    public string SideDishes { get; set; }
    public string Drink { get; set; }
    public string Dessert { get; set; }
    public string Descriere { get; set; }

    // Constructor fara parametri
    public MenuRestaurant()
    {
        MainCourse = string.Empty;
        SideDishes = string.Empty;
        Drink = string.Empty;
        Dessert = string.Empty;
        Descriere = string.Empty;
    }

    // Constructor cu parametri
    public MenuRestaurant(string mainCourse, string sideDishes, string drink, string dessert)
    {
        this.MainCourse = mainCourse;
        this.SideDishes = sideDishes;
        this.Drink = drink;
        this.Dessert = dessert;
        this.Descriere = $"{mainCourse}, {sideDishes}, {drink}, {dessert}";
    }

    // Constructor care preia date dintr-o descriere
    public MenuRestaurant(string descriere)
    {
        var parts = descriere.Split(',');
        if (parts.Length == 4)
        {
            MainCourse = parts[0].Trim();
            SideDishes = parts[1].Trim();
            Drink = parts[2].Trim();
            Dessert = parts[3].Trim();
        }
        else
        {
            MainCourse = string.Empty;
            SideDishes = string.Empty;
            Drink = string.Empty;
            Dessert = string.Empty;
        }
        Descriere = descriere;
    }

    // Метод для получения информации о меню
    public string Info()
    {
        return $"Main Course: {MainCourse}, Side Dishes: {SideDishes}, Drink: {Drink}, Dessert: {Dessert}";
    }
}
