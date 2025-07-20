using CarrotTextRPG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    int x = Console.WindowWidth, y = Console.WindowHeight; // 콘솔 사이즈
    bool turn= true; // 플레이어 턴인지 적 턴인지 구분하는 변수
    private Player player;
    private List<Enemy> CurrentEnemies;
    private List<Enemy> TotalEnemies;
    Random random = new Random();
    int choice = 0; // 메뉴 인디게이터
    private int dungeonCycle = 0;
    private List<string> options = new List<string> { "공격", "아이템", "도주" };

    public BattleScene(Player player)
    {
        this.player = player;
        CurrentEnemies = new List<Enemy>();
        TotalEnemies = new List<Enemy>();
    }

    public override void LoadScene()
    {
        TotalEnemies.Clear();
        CurrentEnemies.Clear();
        Console.Clear();
        Console.CursorVisible = false;
        // UI 들어올거고
        Console.WriteLine("Battle!");
        bool isBattle = true; // 배틀이 진행중인지 확인하는 변수
        int turnCount = 1;
        Console.WriteLine();
        Incounter();


        while (isBattle) // 배틀이 진행중인 동안
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"턴 : {turnCount++}"); // 턴 수 표시
            
            Display(); // 몬스터 UI 표시
            PlayerUI(); // 플레이어 UI 표시

            if (turn) // 플레이어 턴
            {
                BattleTextUI(); // 공격, 아이템, 도주 UI 표시
                PlayerAttack();
                RemoveDeadEnemies();
            }
            else // 적 턴
            {
                EnemyAttack();
            }

            if (CheckWin())
            {
                Reward();
                Console.WriteLine("알 수 없는 생물체를 처치했습니다!");
                Thread.Sleep(300);
                GameManager.Instance.dungeonCycle++; // 던전 사이클 증가
                Console.WriteLine($"현재 던전을 {GameManager.Instance.dungeonCycle}회 클리하셨습니다.");
                Console.ReadKey();
                isBattle = false; // 배틀 종료
                break;
            }
            else if (CheckLose()) // 패배 조건 확인
            {
                Console.WriteLine("눈 앞이 컴컴해졌습니다.");
                Console.ReadKey();
                isBattle = false; // 배틀 종료
                new MainMenuScene().MainMenu();
                break;
            }
            else
            {
                turn = !turn; // 턴 전환
                Console.ReadKey();
            }
        }
        if (GameManager.Instance.dungeonCycle == 1)
        {
            ChooseClass();
        }

        new MainMenuScene().MainMenu(); // 배틀 종료 후 메인 메뉴로 이동
    }

    public void PlayerUI()
    {
        Console.SetCursorPosition(x - 20, 3 * (y / 4));
        Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Class})");
        Console.SetCursorPosition(x - 20, (3 * (y / 4)) + 1);
        Console.WriteLine($"HP : {player.HP}");
        Console.SetCursorPosition(0, 3 * (y / 4) + 2);
        Console.WriteLine(new string('-', x));
    }
    public void BattleTextUI()
    {
        int count = options.Count;
        int spacing = x / (count + 1);
        int positionY = y - 6;


        for (int i=0;i<count; i++)
        {
            int positionX = spacing * (i + 1) - (options[i].Length / 2);
            if (positionX<0)
            {
                positionX = 0;
            }

            Console.SetCursorPosition(positionX, positionY);
            Console.Write(options[i]);
        }
        DrawIndicator(choice, spacing, options, positionY);
    }

    public void DrawIndicator(int choice, int spacing, List<string> option, int positionY) // 플레이어가 공격할 몬스터를 선택하는 인디케이터
    {
        while (true)
        {
            int count = option.Count;

            for (int i=0; i < count; i++)
            {
                int clearPositionX = spacing * (i + 1) - 6;
                Console.SetCursorPosition(clearPositionX, positionY);
                Console.Write("    ");
            }

            int drawPositionX = spacing * (choice + 1) - (option[choice].Length / 2) - 3; ; // 선택한 옵션의 위치
            Console.SetCursorPosition(drawPositionX, positionY);
            Console.Write("▶"); // 인디케이터 표시

            var key=Console.ReadKey(intercept: true).Key; // 키 입력 받기
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    choice--; // 왼쪽으로 이동
                    if (choice < 0) choice = 0; // 범위 초과 방지
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    choice++; // 오른쪽으로 이동
                    if (choice >= count) choice = count - 1; // 범위 초과 방지
                    break;
                case ConsoleKey.Spacebar:
                    Console.SetCursorPosition(0, positionY);
                    Console.Write(new string(' ', x));
                    switch (choice)
                    {
                        case 0:
                            for (int i=0;i<CurrentEnemies.Count;i++)
                            {
                                Console.SetCursorPosition((i+1)*(x / (CurrentEnemies.Count+1))-5, positionY);
                                if (x > 90) { x -= 2; }
                                Console.Write($"{i+1}{CurrentEnemies[i].Name}");
                            }
                            Console.Write("\n\n\n>>");
                            return;
                        case 1: // 아이템
                            new InventoryScene().LoadScene(); // 인벤토리 씬으로 이동
                            continue;
                        case 2: // 도주
                            Console.WriteLine("도주 성공!");
                            Console.ReadKey();
                            new MainMenuScene().MainMenu();
                            return; // 배틀 종료
                    }
                    break;
            }
        }
    }


    public void Incounter() // 몬스터 랜덤 인카운터 
    {
        int incounterNum = random.Next(1, 5); // 1에서 4명까지 필요한만큼 수정 ㄱㄴ

        for (int i = 0; i < incounterNum; i++)
        {
            int randomMonster = random.Next(0, GameManager.Instance.Enemies.Count); // 가지고 있는 몬스터 전부에서 랜덤값 가져오기

            Enemy template = GameManager.Instance.Enemies[randomMonster];
            CurrentEnemies.Add(template.Clone());  // 게임에 나올 몬스터들 리스트
        }
    }

    public void Display() // 임시 ui처리 주석 처리하셔도됩니다.
    {
        int count = CurrentEnemies.Count;
        if (count==0)
        {
            return;
        }
        int spacing = x / (count + 1); // 몬스터 수에 따라 간격 조정
        int nameLine = y / 4;
        int hpLine = nameLine + 1;

        for(int i=0; i<count; i++)
        {
            var enemy = CurrentEnemies[i];
            int positionX = spacing * (i + 1) - (enemy.Name.Length / 2); // 몬스터 이름의 길이에 따라 위치 조정
            if (positionX < 0) positionX = 0; // 위치가 음수로 나오는 경우 방지

            Console.SetCursorPosition(positionX, nameLine);
            Console.WriteLine(enemy.Name); // 몬스터 이름 출력

            Console.SetCursorPosition(positionX, hpLine);
            Console.WriteLine($"HP : {enemy.HP}"); // 몬스터 HP 출력
        }
        Console.SetCursorPosition(0, hpLine+2); // 커서 위치 초기화
        Console.WriteLine();
    }

    private void PlayerAttack()
    {
        string attack = Console.ReadLine(); // 플레이어가 어택할 생명체 번호
        int select;
        Random random = new Random();
        int critical = random.Next(0, 101);

        if (!int.TryParse(attack, out select)) // 숫자만 받을수 있게, 입력받은 숫자를 Select에 넣음
        {
            Console.WriteLine("적을 정확히 노려주세요.");
            return;
        }

        if (select <= CurrentEnemies.Count && select > 0) // Select 보다 적거나 0 보다 많게
        {
            if (critical <= player.Critical)
            {
                CurrentEnemies[select - 1].HP -= (player.AttackBoosted * 160) / 100; // 크리티컬
                Console.WriteLine("크리티컬!");
            }
            else
            {
                CurrentEnemies[select - 1].HP -= player.AttackBoosted; // 현재 선택한 enemy의 hp를 플레이어의 공격력으로 깎는다
            }

            Console.WriteLine($"\n{CurrentEnemies[select - 1].Name} : {CurrentEnemies[select - 1].HP}"); // 주석 가능 
        }
        else
        {
            Console.WriteLine("적을 정확히 노려주세요."); // 예외로 다른 번호 입력할시
            return;
        }
    }



    private void EnemyAttack() // 여기서는 돌림빵만 구현
    {
        foreach (var attack in CurrentEnemies) // 
        {
            int dotge = random.Next(0, 101);

            Console.WriteLine($"{attack.Name}의 공격!");
            if (player.Dodge >= dotge)
            {
                Console.WriteLine("\n적의 공격을 회피했습니다.");
            }
            else
            {
                if (attack.HP > 0)
                {
                    Console.WriteLine($"{attack.Attack}의 피해를 입었다!");
                    player.HP -= attack.Attack;
                }
            }
        }
        Console.WriteLine($"현재 체력 : {player.HP}");
    }

    private void Reward()
    {
        for (int i = 0; i < TotalEnemies.Count; i++)
        {
            player.GainExp(TotalEnemies[i].RwdExp);
            player.Gold += TotalEnemies[i].Gold;
        }
    }
    private bool CheckWin() // 모든 적의 HP가 0 이하이면 true를 반환
    {

        return CurrentEnemies.All(e => e.HP <= 0);
    }
    private bool CheckLose() // 플레이어의 체력이 0 이하이면 true 반환
    {
        return player.HP <= 0;
    }

    private void DrawOption()
    {
        int count= options.Count;
        int spacing = x / (count + 1);
        int positionY = y - 6;
        for (int i = 0; i < count; i++)
        {
            int positionX = spacing * (i + 1) - (options[i].Length / 2);
            if (positionX < 0)
            {
                positionX = 0;
            }
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(options[i]);
        }
    }

    public void ChooseClass()
    {
        Console.Clear();
        Console.WriteLine("힘겹게 한 층을 내려오니 눈 앞에 하나의 석판이 있다.");
        Thread.Sleep(500);
        Console.WriteLine("석판에는 알 수 없는 문자가 새겨져 있다.");
        Thread.Sleep(500);
        Console.WriteLine("석판에 손을 대자, 눈 앞에 문자가 떠오른다.");
        Thread.Sleep(500);

        string[] jobLines = {
                " 1  2  3",
                "전 궁 마",
                "        법",
                "사 수 사"
            };

        foreach (string line in jobLines)
        {
            WriteCentered(line);
            Thread.Sleep(300);
        }
        Console.WriteLine("직업을 선택해주세요.");
        Console.Write(">>>"); // 받은 직업을 DB에 저장되어있는 플레이어의 직업으로 선택
        int? job = int.Parse(Console.ReadLine());
        switch (job)
        {
            case 1:
                Console.WriteLine("전사가 선택되었습니다.");
                GameManager.Instance.Player.Class = "전사";
                GameManager.Instance.Player.Armor += 5; // 전사 직업에 맞춰 스테이터스 조정
                Thread.Sleep(1000);
                Console.WriteLine("몸의 변화가 일어납니다.");
                break;
            case 2:
                Console.WriteLine("궁수가 선택되었습니다.");
                GameManager.Instance.Player.Class = "궁수";
                GameManager.Instance.Player.Critical += 5; // 궁수 직업에 맞춰 스테이터스 조정
                Thread.Sleep(1000);
                Console.WriteLine("몸의 변화가 일어납니다.");
                break;
            case 3:
                Console.WriteLine("마법사가 선택되었습니다.");
                GameManager.Instance.Player.Class = "마법사";
                GameManager.Instance.Player.Attack += 5; // 마법사 직업에 맞춰 스테이터스 조정
                Thread.Sleep(1000);
                Console.WriteLine("몸의 변화가 일어납니다.");
                break;
            default:
                Console.WriteLine("직업을 선택하지 않았습니다.");
                Thread.Sleep(1000);
                Console.WriteLine("몸의 아무런 변화가 일어나지 않습니다.");
                break;

        }

        Console.ReadKey();
    }

    private static void WriteCentered(string text) // 텍스트 가운데 정렬
    {
        int width = Console.WindowWidth;
        int pad = (width - text.Length) / 2;
        if (pad < 0) pad = 0;
        Console.WriteLine(new string(' ', pad) + text);
    }



    private void RemoveDeadEnemies()
    {
        // 이번 턴에 죽은 적들을 찾음
        var defeatedThisTurn = CurrentEnemies.Where(e => e.HP <= 0).ToList();

        foreach (var deadEnemy in defeatedThisTurn)
        {
            Console.WriteLine($"{deadEnemy.Name}을(를) 처치했습니다!");
            TotalEnemies.Add(deadEnemy); // 보상 계산을 위해 totalEnemies 리스트에 추가
        }

        // CurrentEnemies 리스트에서 HP가 0 이하인 모든 적을 제거
        CurrentEnemies.RemoveAll(enemy => enemy.HP <= 0);
    }
}