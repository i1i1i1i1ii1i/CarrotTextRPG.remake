using System;

namespace carrotTextRPG;

public class Enemy
{
    public bool Indigator { get; set; }
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }
    public int RwdExp { get; set; }
    public int Gold { get; set; }

    public Enemy (bool indigator, string name, int hp, int attack, int exp, int gold)
    {
       Indigator = indigator;
       Name = name;
       HP = hp;
       Attack = attack;
       RwdExp = exp;
       Gold = gold;
    }

    public Enemy Clone() // Enemy Clone
    {
        return this.MemberwiseClone() as Enemy;
    }
}