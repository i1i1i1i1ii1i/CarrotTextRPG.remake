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


        // UI 들어올거고
        Console.WriteLine("Battle!");
        Console.WriteLine();
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

       while(true) // 임시
        {
            PlayerAttack();

            EnemyAttack();

        }
    }


    public void Incounter() // 몬스터 랜덤 인카운터 
    {
        Random random = new Random();

        int incounterNum = random.Next(1, 5); // 1에서 4명까지 필요한만큼 수정 ㄱㄴ

        for(int i = 0; i< incounterNum; i++)
        {
            int randomMonster = random.Next(0, TotalEnemies.Count); // 가지고 있는 몬스터 전부에서 랜덤값 가져오기
            CurrentEnemies.Add(TotalEnemies[randomMonster]);  // 게임에 나올 몬스터들 리스트
        }
    }

    public void Display() // 임시 ui처리 주석 처리하셔도됩니다.
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

    private void PlayerAttack()
    {
        string attack = Console.ReadLine(); // 플레이어가 어택할 생명체 번호
        int select;

        if (!int.TryParse(attack, out select)) // 숫자만 받을수 있게, 입력받은 숫자를 Select에 넣음
        {
            Console.WriteLine("숫자만 입력해라 ㅇㅇ;");
        }

        if (select <= CurrentEnemies.Count && select > 0) // Select 보다 적거나 0 보다 많게
        {
            CurrentEnemies[select - 1].HP -= player.Attack; // 현재 선택한 enemy의 hp를 플레이어의 공격력으로 깎는다
            Console.WriteLine($"{CurrentEnemies[select - 1].Name} : {CurrentEnemies[select - 1].HP}"); // 주석 가능 
        }
        else
        {
            Console.WriteLine("있는 애들 번호만 입력해주세요"); // 예외로 다른 번호 입력할시
        }
    }

    private void EnemyAttack() // 여기서는 돌림빵만 구현
    {
        foreach(var attack in CurrentEnemies) // 
        {
            player.HP -= attack.Attack;
        }
        Console.WriteLine($"현재 체력 : {player.HP}");
    }


    private void EnemyInit() // 몬스터 전체, 필요한 몬스터 있으면 여기에 추가, 이름 체력 공격력 수정 ㄱㄴ
    {
        TotalEnemies.Add(new Enemy("사람", 50, 5));
        TotalEnemies.Add(new Enemy("괴물", 40, 3));
        TotalEnemies.Add(new Enemy("외계생명체", 30, 4));
        TotalEnemies.Add(new Enemy("돌", 20, 1));

    }
    private void RemoveDeadEnemies() // 리스트에서 피가 0 이하로 내려가면 제거
    {
        CurrentEnemies.RemoveAll(enemy => enemy.HP <= 0);
    }
}