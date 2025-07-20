using System;

namespace carrotTextRPG;

public class Item
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Armor { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public bool Purchased { get; set; }
    public bool Equipped { get; set; }

    public Item(string name, int attack, int armor, string type, string description, int price, bool purchased = false) // 아이템 생성자
    {
        Name = name;
        Attack = attack;
        Armor = armor;
        Type = type;
        Description = description;
        Price = price;
        Purchased = purchased;
        Equipped = false;
    }

    public string GetStatText() 
    {
        if (Attack > 0) return $"공격력 +{Attack}";
        else if (Armor > 0) return $"방어력 +{Armor}";
        else return "능력치 없음";
    }
}