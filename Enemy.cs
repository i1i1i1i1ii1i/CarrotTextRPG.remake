using System;

namespace carrotTextRPG;

public class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int RwdExp { get; set; }

    public Enemy (string name, int hp, int attack, int exp)
    {  
       Name = name;
       HP = hp;
       Attack = attack;
       RwdExp = exp;
    }

    public Enemy Clone() // Enemy Clone
    {
        return this.MemberwiseClone() as Enemy;
    }
}