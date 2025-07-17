using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    private Player player;
    private List<Enemy> TotalEnemies;
    private List<Enemy> CurrentEnemies;

    
    
    public BattleScene(Player player)
    {
        this.player = player;
        TotalEnemies = new List<Enemy>();
        CurrentEnemies = new List<Enemy>();

        EnemyInit();
    }

    public override void LoadScene()
    {
        Console.Clear();

        bool isMyturn = true;

        // UI 들어올거고
        Console.WriteLine("Battle!");
        
        // while 문 처리하고 
        Incounter(); // 씬 들어왔을때 랜덤으로 인카운터 해주고 ui에 표시
        Display();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("[내정보]");
        Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Class}");
        Console.WriteLine($"{player.HP}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. 공격");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요");
        Console.WriteLine(">>");

        // while로 묶일듯

        if(isMyturn)
        {
            string PlayerAction = Console.ReadLine(); // 플레이어의 행동을 int 값으로 받는다.



            if (PlayerAction != "1") // 잠시 예외처리
            {
                Console.WriteLine("메뉴에 있는 숫자만 입력해주세요");
            }

            switch (PlayerAction)
            {
                case "1":
                    // enemy.hp - plyaer.attack 같은 느낌
                    isMyturn = false;
                    // loadscene
                    break;
            }
        }

        if(!isMyturn)
        {
            // 여기서 몬스터가 공격할듯

            // player에 참조
        }

       



        //필요한거
        //바로 시작
        // 던전씬
        // w로만 전진
        // 쉬는곳, 몬스터 인카운터
        // ㅇㅇ  ㅇㅇ
        // ㅇㅇ  ㅇㅇ
        // ㅇㅇ  ㅇㅇ
        // ㄹㄹ  ㄹㄹ
        // ㄱㄱ  ㄱㄱ
        // ㅇㅇㅁㅇㅇ

    }


    public void Incounter() // 몬스터 랜덤 인카운터 
    {
        Random random = new Random();

        int incounterNum = random.Next(1, 5);

        for(int i = 0; i< incounterNum; i++)
        {
            int randomMonster = random.Next(0, TotalEnemies.Count); // << 몬스터의 리스트의 인덱스
            CurrentEnemies.Add(TotalEnemies[randomMonster]);
        }
    }

    public void Display()
    {
        foreach(var enemy in CurrentEnemies)
        {
            Console.Write($"{enemy.Name} / {enemy.Attack} \t");
        }
        Console.WriteLine();
        foreach (var enemy in CurrentEnemies)
        {
            Console.Write($"   {enemy.HP}   ");
        }
    }

    public void AttackEnemy()
    {

    }

    public void TakeDamage()
    {

    }

    public void Turn()
    {

    }

    private void EnemyInit()
    {
        TotalEnemies.Add(new Enemy("사람", 50, 5));
        TotalEnemies.Add(new Enemy("괴물", 40, 3));
        TotalEnemies.Add(new Enemy("외계생명체", 30, 4));
        TotalEnemies.Add(new Enemy("돌", 20, 1));
    }
}