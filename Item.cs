using System;

namespace carrotTextRPG;

public class Item
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Armor { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool Purchased { get; set; }
    public bool Equipped { get; set; } = false;
    public Item(string name, int attack, int armor, string description, int price)
    {
        Name = name;
        Attack = attack;
        Armor = armor;
        Description = description;
        Price = price;
    }
    public string GetStatText()
    {
        if (Attack > 0) return $"���ݷ� +{Attack}";
        else if (Armor > 0) return $"���� +{Armor}";
        else return "�ɷ�ġ ����";
    }
}