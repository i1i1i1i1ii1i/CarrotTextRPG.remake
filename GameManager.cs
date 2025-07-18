using CarrotTextRPG;
using System;
using System.Collections.Generic;

namespace carrotTextRPG;

public class GameManager
{

    private static GameManager instance;
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>();


    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();

            return instance;
        }
    }


    public Player Player { get;  set; }
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
            Inventory = new List<Item>(),
            Critical = 15,
            Dodge = 10,
        };
        Items = new List<Item>();
    }


    //public void AddItem(string name, int attack, int armor, string description, int price, bool purchased = false)
    //{
    //    var item = new Items();

    //    Items.Add(item);
    //}

    public void AddEnemy(string name, int hp, int attack) // 적 추가
    {
        var enemy = new Enemy(name, hp, attack);
        Enemies.Add(enemy);
    }
}