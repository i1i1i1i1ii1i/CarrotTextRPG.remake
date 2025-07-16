using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    List<Enemy> EnemyList = new List<Enemy>();
    

    public override void LoadScene()
    {
        bool isMyturn = true;

        Player player = new Player();
        // UI 들어올거고
        Console.WriteLine("Battle!");

        // while 문 처리하고 
        Incounter(); // 씬 들어왔을때 랜덤으로 인카운터 해주고 ui에 표시

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
        Enemy enemy = new Enemy();

        int incounterNum = random.Next(1, 5);

        for(int i = 0; i< incounterNum; i++)
        {
            int randomMonster = random.Next(0, 4); // << 몬스터의 리스트의 인덱스
            Console.WriteLine(randomMonster); // 리스트 인덱스로 값받아와서 0 1 2 3;
           // list(i) 에 해당하는 몬스터의 Status 불러오고 표시
           // Console.WriteLine($"Lv.{enemy.Level} {enemy.Name} {enemy.HP}"); 
        }
    }

    public void Turn()
    {

    }
}