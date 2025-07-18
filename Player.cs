using System;

namespace carrotTextRPG;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string Class { get; set; }
    public int Attack { get; set; }
    public int HP { get; set; }
    public int Armor { get; set; }
    public int Gold { get; set; }
    public int Critical { get; set; }
    public int Dodge { get; set; }
    public List<Item> Inventory { get; set; }
}