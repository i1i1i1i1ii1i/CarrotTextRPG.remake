using System;

namespace carrotTextRPG;

public class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }

    public Enemy (string name, int hp, int attack) // Enemy »ý¼ºÀÚ 
    {  Name = name; HP = hp; Attack = attack; } 

    public Enemy Clone() // Enemy Clone
    {
        return this.MemberwiseClone() as Enemy;
    }
}