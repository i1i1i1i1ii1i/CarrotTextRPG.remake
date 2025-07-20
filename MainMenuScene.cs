using CarrotTextRPG;
using System;

namespace carrotTextRPG;

public class MainMenuScene : SceneLoader
{
    static int x = Console.WindowWidth, y = Console.WindowHeight; // 콘솔 사이즈
    //string saveFile=SaveScene.FilePath; // 상대경로 (동일하게 맞춤)

    public MainMenuScene()
    {
        GameManager.Instance.AddEnemy(false,"사람", 50, 5,20,30);
        GameManager.Instance.AddEnemy(false,"괴물", 40, 3,15,50);
        GameManager.Instance.AddEnemy(false, "외계생명체", 30, 4, 10,100);
        GameManager.Instance.AddEnemy(false, "돌", 20, 1, 5,5);
    }
    public override void LoadScene()
    {
        Console.Clear();
        PrologueScene();
        Console.ReadKey();
        Console.Clear();
        CreatPlayer();
        Console.ReadKey();
        Console.Clear();
        MainMenu();
    }
        
    public void PrologueScene()
    {
        Console.Clear();
        Console.WriteLine("\n따가운 햇살이 눈꺼풀 사이로 파고든다.");
        Thread.Sleep(300);
        Console.WriteLine("뜨거운 모래 위에 몸을 뉘인 채, 당신은 천천히 정신을 되찾는다.");
        Thread.Sleep(300);
        Console.WriteLine("주변을 둘러보지만, 인적은커녕 발자국 하나 보이지 않는다.");
        Thread.Sleep(300);
        Console.WriteLine("정신은 몽롱하고, 입은 짠 물로 가득 차 있다.");
        Thread.Sleep(300);
        Console.WriteLine("당신은 온몸이 젖어있는 걸 깨닫는다.");
        Thread.Sleep(300);
        Console.WriteLine("당신은 누구인가?");
        Thread.Sleep(300);
        Console.WriteLine("어째서 이 외딴 섬에 홀로 있는 것인가?");
        Thread.Sleep(300);
    }

    public void CreatPlayer()
    {

        Console.WriteLine("\n품 안에서 날카로운 것에 긁히는 기분이 들어 옷 속을 살펴보니");
        Thread.Sleep(300);
        Console.Write("짧은 날붙이 하나와 가죽으로 둘러싸여 있는 ");
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("책");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("이 한권 나왔다.");
        Thread.Sleep(300);
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("책");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("을 펼쳐볼까?");
        Console.ReadKey();
        Console.Write("\n갈색 가죽으로 덮인 책의 오른쪽 구석에 검은색 잉크로 ");
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("무언가");
        Console.ResetColor();
        Console.WriteLine("가 적혀 있다.");
        Thread.Sleep(300);
        string nameInput;

        do
        {
            Console.Write("\n>> ");
            nameInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nameInput))
            {
                Console.WriteLine("\n중요해보인다. 다시 확인해볼까?");
            }
        }
        while (string.IsNullOrWhiteSpace(nameInput));

        GameManager.Instance.GeneratePlayer(nameInput);
        Console.WriteLine($"\n{GameManager.Instance.Player.Name}");
        Thread.Sleep(500);
        Console.WriteLine("무슨 의미인지는 모르겠지만");
        Thread.Sleep(500);
        Console.WriteLine("뭔가 입에 익은 느낌이 든다");
    }

    public void MainMenu()
    {
        bool isRunning = true;
        string[] scene = { "상  태", "전  투", "상  점","휴 식", "종 료" };
        int choice = 1;
        int leftmargin = -3;
        int columns = scene.Length; // 4
        int columnWidth = x / (columns); // 25
        int spacing = x / (columns + 1); // 20
        Console.BackgroundColor = ConsoleColor.Black;

        while (isRunning)
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.SetCursorPosition(0, y / 2);
            for (int i = 0; i < columns; i++)
            {
                int spc = leftmargin + spacing * (i + 1); // 각 컬럼 사이의 간격
                Console.SetCursorPosition(spc, y / 2);
                Console.Write(scene[i]);
            }

            int idx = choice - 1;
            int baseX = leftmargin + spacing * (idx + 1) - 2;
            Console.SetCursorPosition(baseX, y / 2);
            Console.Write("▶");

            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.A:
                    choice = Math.Clamp(choice - 1, 1, columns);
                    break;
                case ConsoleKey.D:
                    choice = Math.Clamp(choice + 1, 1, columns);
                    break;
                case ConsoleKey.Spacebar:
                    switch (choice)
                    {
                        case 1:
                            new StatusScene().LoadScene();
                            break;
                        case 2:
                            if (GameManager.Instance.Player.HP > 0) { new BattleScene(GameManager.Instance.Player).LoadScene(); }
                            else { Console.SetCursorPosition(x/2-9,y/3); Console.Write("체력이 부족합니다."); Console.ReadKey(); MainMenu(); }
                            break;
                        case 3:
                            new ShopScene().LoadScene();
                            break;
                        case 4:
                            if (GameManager.Instance.Player.Gold < 300)
                            {
                                Console.SetCursorPosition(x / 2-10, y / 3);
                                Console.WriteLine("소지금이 부족합니다");
                                Console.ReadKey();
                            } 
                            else if (GameManager.Instance.Player.HP == GameManager.Instance.Player.MaxHP)
                            {
                                Console.SetCursorPosition(x / 2-13, y / 3);
                                Console.WriteLine("체력이 이미 가득 찼습니다.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.SetCursorPosition(x / 2-8, y / 3);
                                Console.WriteLine("휴식을 취합니다.");
                                GameManager.Instance.Player.Gold -= 300;
                                GameManager.Instance.Player.HP = GameManager.Instance.Player.MaxHP;
                                Console.ReadKey();
                            }
                            break;
                        case 5:
                            new SaveScene().LoadScene();
                            break;
                    }
                    break;
            }
        }
    }



    private void ShowErrorMsg()
    {
        Console.WriteLine("잘못된 입력. 다시 시도하세요.");
    }
}