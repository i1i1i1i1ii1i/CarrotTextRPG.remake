using CarrotTextRPG;
using System;
using System.Collections.Generic;

namespace carrotTextRPG;

public class GameManager
{
    private static GameManager instance; // 게임 매니저 싱글톤
    public List<Item> Items { get; private set; } = new List<Item>(); // 아이템을 담을 리스트
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>(); //적 담을 리스트

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

    public void GeneratePlayer(string name) // 플레이어 생성
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

    //public void AddItem(string name, string type, int buffValue, int itemNumber) // 아이템 추가
    //{
    //    var item = new Item(name, type, buffValue, itemNumber);
    //    Items.Add(item);
    //}

    public void AddEnemy(string name, int hp, int attack) // 적 추가
    {
        var enemy = new Enemy(name, hp, attack);
        Enemies.Add(enemy);
    }
}