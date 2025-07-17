using System;

namespace carrotTextRPG;

//public class Item
//{
//    public string Name { get; set; }
//    public string Type { get; set; }
//    public int BuffValue { get; set; } // ¾ÆÀÌÅÛÀÌ ÁÖ´Â È¿°ú
//    public int itemNum { get; set; }
//}

public struct Item 
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Armor { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool Purchased { get; set; }
    public bool Equipped { get; set; }
    public Item(string name, int attack, int armor, string description, int price, bool purchased = false)
    {
        Name = name;
        Attack = attack;
        Armor = armor;
        Description = description;
        Price = price;
        Purchased = purchased;
        Equipped = false;
    }
    public string GetStatText()
    {
        if (Attack > 0) return $"°ø°Ý·Â +{Attack}";
        else if (Armor > 0) return $"¹æ¾î·Â +{Armor}";
        else return "´É·ÂÄ¡ ¾øÀ½";

    }
}