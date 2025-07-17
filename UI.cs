using System;

namespace carrotTextRPG
{
    public class UI
    {
        public static void ShowLOGO()
        {
            Console.WriteLine(",------.                                       ,--.       ,--.                   ,--. ");
            Console.WriteLine("|  .---' ,---.  ,---. ,--,--. ,---.  ,---.     |  | ,---. |  | ,--,--.,--,--,  ,-|  | ");
            Console.WriteLine("|  `--, (  .-' | .--'' ,-.  || .-. || .-. :    |  |(  .-' |  |' ,-.  ||      \\' .-. | ");
            Console.WriteLine("|  `---..-'  `)\\ `--.\\ '-'  || '-' '\\   --.    |  |.-'  `)|  |\\ '-'  ||  ||  |\\ `-' | ");
            Console.WriteLine("`------'`----'  `---' `--`--'|  |-'  `----'    `--'`----' `--' `--`--'`--''--' `---'  ");
            Console.ReadKey();
        }
        public static void StartScript()
        {
            Console.Clear();
            Console.WriteLine("따가운 햇살이 눈꺼풀 사이로 파고든다.");
            Thread.Sleep(500);
            Console.WriteLine("뜨거운 모래 위에 몸을 뉘인 채, 당신은 천천히 정신을 되찾는다.");
            Thread.Sleep(500);
            Console.WriteLine("주변을 둘러보지만, 인적은커녕 발자국 하나 보이지 않는다.");
            Thread.Sleep(500);
            Console.WriteLine("정신은 몽롱하고, 입은 짠 물로 가득 차 있다.");
            Thread.Sleep(500);
            Console.WriteLine("당신은 온몸이 젖어있는 걸 깨닫는다.");
            Thread.Sleep(500);
            Console.WriteLine("당신은 누구인가?");
            Thread.Sleep(500);
            Console.WriteLine("어째서 이 외딴 섬에 홀로 있는 것인가?");
            Thread.Sleep(500);
            Console.ReadKey();
        }
        public static void CreatCharacter()
        {
            Console.Clear();
            Console.WriteLine("품 안에서 날카로운 것에 긁히는 기분이 들어 옷 속을 살펴보니");
            Thread.Sleep(500);
            Console.WriteLine("짧은 날붙이 하나와 가죽으로 둘러싸여 있는 책이 한권 나왔다.");
            Thread.Sleep(500);
            Console.Write("갈색 가죽으로 덮인 책의 오른쪽 구석에 검은색 잉크로 ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("무언가");
            Console.ResetColor();
            Console.WriteLine("가 적혀 있다.");
            Thread.Sleep(500);
            Console.WriteLine(">> 이름을 입력해주세요.");
            string name = Console.ReadLine(); // 이름을 입력받아 DB에 저장
            Console.WriteLine($"{name}");
            Console.WriteLine("무슨 의미인지는 모르겠지만");
            Thread.Sleep(500);
            Console.WriteLine("뭔가 입에 익은 느낌이 든다.");
            Thread.Sleep(500);
            Console.ReadKey();
        }

        public static void ChooseClass()
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
        "      법",
        "사 수 사"
    };

            foreach (string line in jobLines)
            {
                WriteCentered(line);
                Thread.Sleep(300);
            }
            Console.WriteLine("직업을 선택해주세요.");
            Console.Write(">>>"); // 받은 직업을 DB에 저장되어있는 플레이어의 직업으로 선택
            int job = int.Parse(Console.ReadLine());
            switch(job){
                case 1:
                    Console.WriteLine("전사가 선택되었습니다.");
                    //스테이터스 전사로 조정
                    break;
                case 2:
                    Console.WriteLine("궁수가 선택되었습니다.");
                    //스테이터스 궁수로 조정
                    break;
                case 3:
                    Console.WriteLine("마법사가 선택되었습니다.");
                    //스테이터스 마법사로 조정
                    break;

            }
            Thread.Sleep(1000);
            Console.WriteLine("스테이터스가 직업에 맞춰 조정됩니다.");

            Console.ReadKey();
        }

        public static void ShowStatus()
        {
            Console.Clear();
            Console.WriteLine("계단 앞의 석판을 만지자 글씨가 빛납니다.");
            Thread.Sleep(1000);
            Console.WriteLine("이  름: 플레이어"); // DB에서 Player의 Name을 가져와서 출력
            Thread.Sleep(500);
            Console.WriteLine("직  업: 전사"); // DB에서 Player의 Job을 가져와서 출력
            Thread.Sleep(500);
            Console.WriteLine("레  벨: 1"); // DB에서 Player의 레벨을 가져와서 출력
            Thread.Sleep(500);
            Console.WriteLine("체  력: 100 / 100"); // DB에서 Player의 CurrentHP와 MaxHP를 가져와서 출력
            Thread.Sleep(500);
            Console.WriteLine("마  나: 50 / 50"); // DB에서 Player의 CurrentMP와 MaxMP를 가져와서 출력
            Thread.Sleep(500);
            Console.WriteLine("공격력: 10"); // DB에서 Player의 Attack을 가져와서 출력
            Thread.Sleep(500);
            Console.WriteLine("방어력: 5"); // DB에서 Player의 Defense를 가져와서 출력
            Thread.Sleep(1000);
            Console.ReadKey();
        }
        public static void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("당신의 가방에서 소지품을 확인합니다.");
            Thread.Sleep(1000);
            //foreach (var item in GameManager.Player.Inventory) // DB에서 Player의 Inventory를 가져와서 출력
            //{
            //    Console.WriteLine($"{item.EquiMark} {item.Name} | ");
            //    Thread.Sleep(500);
            //}
        }

        public static void DungeonEnter()
        {
            Console.Clear();
            Console.WriteLine("하나밖에 없는 통로에 들어섭니다.");
            Thread.Sleep(1000);
            Console.WriteLine("동굴은 어둡고, 무척 좁습니다.");
            Thread.Sleep(500);
            Console.WriteLine("당신은 앞으로 전진하는 수 밖에 없다는 것을 깨닫습니다.");
            Console.ReadKey();
        }

        public static void DungeonPhase()
        {
            Console.Clear();
        }

        public static void NormalScript()
        {
            Console.Clear();
            Console.CursorVisible = false;

            DrawUILayout();

            DrawToDisplay("디스플레이 영역");
            DrawNormalTextBox("텍스트 영역");
        }

        public static void DungeonUI()
        {
            Console.Clear();
            Console.CursorVisible = false;

            DrawDungeonUILayout();

            DrawToDisplay("던전 디스플레이 영역");
            DrawNormalTextBox("던전 텍스트 영역");
        }

        public static void DrawUILayout()
        {
            for (int i = 25; i < 35; i++)
            {
                Console.Clear();
                Console.SetCursorPosition(0, i);
                Console.Write(new string('-', 90));
            }
        }

            public static void DrawDungeonUILayout()
        {
            Console.SetCursorPosition(0, 25);
            Console.Write(new string('-', 90));

            for (int i = 26; i < 50; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', 90));
            }
        }

        public static void DrawToDisplay(string text)
        {
            Console.SetCursorPosition(0, 2);
            ShowLOGO();
        }

        public static void DrawNormalTextBox(string text)
        {
            Console.SetCursorPosition(0, 26);
            Console.WriteLine(text);
        }

        private static void WriteCentered(string text) // 텍스트 가운데 정렬
        {
            int width = Console.WindowWidth;
            int pad = (width - text.Length) / 2;
            if (pad < 0) pad = 0;
            Console.WriteLine(new string(' ', pad) + text);
        }
    }
}
