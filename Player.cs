using System;
using System.Net.Security;

namespace carrotTextRPG;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public float Exp { get; set; }
    public string Class { get; set; }
    public int Attack { get; set; }
    public int HP { get; set; }
    public int Armor { get; set; }
    public int Gold { get; set; }
    public int Critical { get; set; }
    public int Dodge { get; set; }
    public List<Item> Inventory { get; set; }

    public float MaxExp
    { 
        get
        {
            return 100 + (Level - 1.1);
        } 
    }

    public void GainExp(float expAmount)
    {
        Exp += expAmount;

        while (Exp >= MaxExp)
        {
            Exp -= MaxExp;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        
        switch (Class)
        {
            case "전사" : 
                HP += 10;
                Attack += 5;
                Armor += 5;
                Critical += 1;
                Dodge += 1;
                break;
            case "궁수" : 
                HP += 5;
                Attack += 5;
                Armor += 1;
                Critical += 5;
                Dodge += 10;
                break;
            case "마법사" : 
                HP += 1;
                Attack += 20;
                Armor += 1;
                Critical += 1;
                Dodge += 1;
                break;
        }
    }
}

