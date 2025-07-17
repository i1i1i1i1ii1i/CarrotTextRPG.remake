using System;
using System.Collections.Generic;
using CarrotTextRPG;

namespace carrotTextRPG;

public class GameManager
{
    private static GameManager instance;
    public List<Item> Items { get; private set; } = new List<Item>();
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();

    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();

            return instance;
        }
    }

    public Player Player { get; private set; }
    //public List<Enemy> Enemies { get; private set; }
    //public List<Item> Items { get; private set; }

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
            Critical = 15,
            Dodge = 10,
            Inventory = new List<Item>()
        };
    }

    public void AddItem(string name, string type, int buffValue, int itemNumber)
    {
        var item = new Item(name, type, buffValue, itemNumber);
        Items.Add(item);
    }

    public void AddEnemy(string name, int hp, int attack)
    {
        var enemy = new Enemy(name, hp, attack);
        Enemies.Add(enemy);
    }
}