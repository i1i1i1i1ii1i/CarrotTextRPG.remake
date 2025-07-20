using CarrotTextRPG;
using System;
using System.Collections.Generic;

namespace carrotTextRPG;

public class GameManager
{
    private static GameManager instance;
    public Player Player { get; set; }
    public List<Enemy> Enemies { get; private set; } = new List<Enemy>(); // Enemies 담을 리스트 형태의 그릇
    public List<Item> Items { get; private set; } = new List<Item>();// 아이템

    public static GameManager Instance // 게임 매니저 싱글톤
    {
        get
        {
            if (instance == null) instance = new GameManager();

            return instance;
        }
    }

    public void GeneratePlayer(string name) // 플레이어 생성 함수; 파라미터는 MainMenuScene 에서 유저한테 입력 받아온 값
    {
        Player = new Player()
        {
            Name = name,
            Level = 1,
            Exp = 0,
            Class = "",
            HP = 100,
            Attack = 10,
            Armor = 5,
            Gold = 1500,
            Inventory = new List<Item>(),
            Critical = 15,
            Dodge = 10,
        };
    }

    public void AddItem(string name, int attack, int armor, string type, string description, int price, bool purchased = false)
    {
        var item = new Item(name, attack, armor, type, description, price, purchased);
        Items.Add(item);
    }
    public void AddEnemy(string name, int hp, int attack, int exp) // 적 추가
    {
        var enemy = new Enemy(name, hp, attack,exp);
        Enemies.Add(enemy);
    }
}