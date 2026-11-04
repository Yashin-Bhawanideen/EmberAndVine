namespace EmberAndVine.Models;

public record MenuItem(string Name, string Description, decimal Price, string Category, string Image, string? Tag = null);

public static class MenuData
{
    public static readonly string[] Categories = { "Starters", "Mains", "Desserts" };

    public static readonly IReadOnlyList<MenuItem> Items = new List<MenuItem>
    {
        new("Charred Octopus", "Slow-braised, finished over coals, smoked paprika purée, charred lemon.", 135m, "Starters", "octopus.svg"),
        new("Burrata & Heirloom Tomato", "Creamy burrata, sun-ripened tomatoes, basil oil, flaked sea salt.", 115m, "Starters", "burrata.svg", "Vegetarian"),
        new("Wild Mushroom Arancini", "Crisp golden rice spheres, truffle mayo, aged parmesan.", 98m, "Starters", "arancini.svg", "Vegetarian"),

        new("Dry-Aged Ribeye, 300g", "Thirty-day aged, cooked over vine wood, bone-marrow butter, rocket.", 325m, "Mains", "ribeye.svg", "Signature"),
        new("Pan-Seared Kingklip", "Crisp skin, saffron beurre blanc, charred baby leeks.", 265m, "Mains", "kingklip.svg", "Signature"),
        new("Rack of Lamb", "Herb crust, rosemary jus, smoked aubergine, pickled shallots.", 345m, "Mains", "lamb.svg"),
        new("Wild Mushroom Risotto", "Carnaroli rice, porcini, thyme, aged parmesan, truffle oil.", 185m, "Mains", "risotto.svg", "Vegetarian"),

        new("Dark Chocolate Fondant", "Warm molten centre, salted caramel, vanilla bean cream.", 105m, "Desserts", "fondant.svg", "Signature"),
        new("Malva Pudding Brûlée", "Our take on the South African classic, torched sugar crust, amarula custard.", 95m, "Desserts", "malva.svg"),
        new("Vanilla Panna Cotta", "Silky set cream, macerated berries, pistachio crumb.", 92m, "Desserts", "panna.svg", "Vegetarian"),
    };

    public static IEnumerable<MenuItem> Signature => Items.Where(i => i.Tag == "Signature");
}
