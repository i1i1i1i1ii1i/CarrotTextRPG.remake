using CarrotTextRPG;
using System;

namespace carrotTextRPG;

public class MainMenuScene : SceneLoader
{
<<<<<<< Updated upstream
=======
    static int x = Console.WindowWidth, y = Console.WindowHeight; // 콘솔 사이즈

    public MainMenuScene()
    {
        GameManager.Instance.AddEnemy("사람", 50, 5,20);
        GameManager.Instance.AddEnemy("괴물", 40, 3,15);
        GameManager.Instance.AddEnemy("외계생명체", 30, 4, 10);
        GameManager.Instance.AddEnemy("돌", 20, 1, 5);
    }
>>>>>>> Stashed changes
    public override void LoadScene()
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
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("\n품 안에서 날카로운 것에 긁히는 기분이 들어 옷 속을 살펴보니");
        Thread.Sleep(300);
        Console.WriteLine("짧은 날붙이 하나와 가죽으로 둘러싸여 있는 책이 한권 나왔다.");
        Thread.Sleep(300);
        Console.Write("갈색 가죽으로 덮인 책의 오른쪽 구석에 검은색 잉크로 ");
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
        Console.ReadKey();
        Console.Clear();
 
        bool isRunning = true;
        string[] scene = { "상  태", "전  투", "상  점", "종 료"};
        int choice = 1;
        int leftmargin = -3;
        int columns = scene.Length; // 4
        int columnWidth = x / (columns); // 25
        int spacing = x/(columns + 1); // 20

        while (isRunning)
        {  
            Console.CursorVisible = false;
            Console.Clear();

<<<<<<< Updated upstream
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n\n0. 종료 \n1. 상태 보기\n2. 전투 시작\n3. 상점\n\n원하시는 행동을 입력해주세요.\n>>");

            
            Console.Write("\n원하시는 행동을 입력해주세요.\n >>");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int inputInt))
=======
            Console.SetCursorPosition(0, y / 2);
            for(int i=0; i< columns; i++)
>>>>>>> Stashed changes
            {
                int spc = leftmargin + spacing * (i+1); // 각 컬럼 사이의 간격
                Console.SetCursorPosition(spc, y / 2);
                Console.Write(scene[i]); 
            }

            int idx = choice-1;
            int baseX = leftmargin + spacing * (idx + 1) - 2; // 0 * 25 + 25 / 2
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
<<<<<<< Updated upstream
                case 2:
                    new BattleScene().LoadScene();
                    break;
                default:
                    ShowErrorMsg();
                    break;
            }
            //if (int.TryParse(input, out inputInt) == false)
            //{
            //    ShowErrorMsg();
            //    continue;
            //}


            // else if (inputInt == 2)
            // {
            //     SceneLoader battleScene = new BattleScene();
            //     battleScene.LoadScene();
            // }
            // else if (inputInt == 3)
            // {
            //     SceneLoader shopscene = new ShopScene();
            //     shopscene.LoadScene();
            // }
            // else ShowErrorMsg();

            //if (inputInt == 0) return;

            //else if (inputInt == 1)
            //{
            //    SceneLoader statusScene = new StatusScene();
            //    statusScene.LoadScene();
            //}

            //else if (inputInt == 2)
            //{
            //    SceneLoader battleScene = new BattleScene();
            //    battleScene.LoadScene();
            //}
            //else ShowErrorMsg();

=======
                case ConsoleKey.Spacebar:
                    switch (choice)
                    {
                        case 1:
                            new StatusScene().LoadScene();
                            break;
                        case 2:
                            new BattleScene(GameManager.Instance.Player).LoadScene();
                            break;
                        case 3:
                            new ShopScene().LoadScene();
                            break;
                        case 4:
                            new SaveScene().LoadScene();
                            break;
                    }
                    break;
            }
>>>>>>> Stashed changes
        }
    }
        
    

    private void ShowErrorMsg()
    {
        Console.WriteLine("잘못된 입력. 다시 시도하세요.");
    }
}