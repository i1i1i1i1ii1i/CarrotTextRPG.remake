using System;

namespace carrotTextRPG;

//public class Enemy
//{
//    public string Name { get; set; }
//    public int HP { get; set; }
//    public int Attack { get; set; }
//}

public class Enemy
{
    public string Name { get; set; }
    public int HP { get; set; }
    public int Attack { get; set; }

    public Enemy (string name, int hp, int attack)
    {  Name = name; HP = hp; Attack = attack; }
}