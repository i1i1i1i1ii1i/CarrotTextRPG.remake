using CarrotTextRPG;
using System;
using System.Collections.Generic;

namespace carrotTextRPG;

public class GameManager
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();

            return instance;
        }
    }

    public Player Player { get;  set; }
    public List<Enemy> Enemies { get; private set; }
    public List<Item> Items { get; private set; }

    public void GeneratePlayer(string name)
    {
        Player = new Player()
        {
            Name = name,
            Level = 1,
            HP = 100,
            Attack = 10,
            Armor = 5,
            Gold = 1500,

            Inventory = new List<Item>()
            
        };
        Items = new List<Item>();
    }
}

