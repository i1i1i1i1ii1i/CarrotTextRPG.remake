using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static Program;

internal partial class Program
{


    public class Player
    {
        internal int hp;

        public string Name { get; set; }
        public string Job { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

    }


    private static int Level = 01;
    private static int 공격력 = 10;
    private static int 방어력 = 5;
    private static int 체력 = 100;
    private static int 돈 = 200;






    //게임 시작
    private static void Main(string[] args)
    {

        Console.WriteLine(" ===============================");
        Console.WriteLine("|                               |");
        Console.WriteLine("|텍스트 RPG에 오신 걸 환영합니다|");
        Console.WriteLine("|                               |");
        Console.WriteLine(" ===============================");
        Console.WriteLine();
        Console.Write("이름을 입력하십시오: ");
        string PlayerName = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("어서오세요! {0}님", PlayerName);

        Console.WriteLine("\n1:전사\n");
        Console.WriteLine("2:도적\n");
        Console.WriteLine("3:마법사\n");
        Console.Write("직업을 선택 하십시오: ");

        int job = int.Parse(Console.ReadLine());

        Player player = new Player();
        player.Name = PlayerName;
        Console.Clear();


        //직업 선택
        switch (job)
        {
            case 1:
                Console.WriteLine("[전사를 선택하셨습니다.]\n");
                player.Job = "전사";
                break;
            case 2:
                Console.WriteLine("[도적을 선택하셨습니다.]\n");
                player.Job = "도적";
                break;
            case 3:
                Console.WriteLine("[마법사를 선택하셨습니다.]\n");
                player.Job = "마법사";
                break;
            default:
                Console.WriteLine("올바른 번호를 입력해주십시오.");
                return;
        }


        Console.WriteLine("아무 키나 누르면 마을로 이동합니다...");
        Console.ReadKey();

        Game(player);
    }


    private static void Game(Player player)
    {
        while (true)
        {
            //마을
            Console.Clear();
            Console.WriteLine("환영합니다!. 마을에 잘 오셨습니다.");
            Console.WriteLine("\n당신의 직업은 [{0}]입니다.", player.Job);
            Console.WriteLine();
            Console.WriteLine("1. 인벤토리\n");
            Console.WriteLine("2. 정보창\n");
            Console.WriteLine("3. 상점\n");
            Console.WriteLine("4. 던전입장\n");
            Console.Write("선택: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowInventory(player);
                    break;
                case "2":
                    ShowPlayerInfo(player);
                    break;
                case "3":
                    EnterShop(player);
                    break;
                case "4":
                    EnterDungeon(player);
                    break;
                default:
                    Console.WriteLine("올바른 번호를 입력해주십시오.");
                    Console.ReadKey();
                    break;

            }

            static void ShowInventory(Player player)
            {
                //인벤
                Console.Clear();
                Console.WriteLine("[인벤토리]\n");
                Console.WriteLine("무기: 낡은 검\n");
                Console.WriteLine("방어구: 낡은 갑옷\n");
                Console.WriteLine("HP물약: 3개\n");
                Console.WriteLine("MP물약: 3개\n");
                Console.WriteLine("아무 키나 누르면 마을로 이동합니다.");
                Console.WriteLine();
                Console.ReadKey();
            }

            static void ShowPlayerInfo(Player player)
            {
                Console.Clear(); //스탯창
                Console.WriteLine("[ 정보 ]\n");
                Console.WriteLine($"Lv. {Level:D2}\n");
                Console.WriteLine($"공격력 : {공격력}\n");
                Console.WriteLine($"방어력 : {방어력}\n");
                Console.WriteLine($"체력 : {체력}\n");
                Console.WriteLine($"돈 : G{돈}\n");
                Console.WriteLine("아무 키나 누르면 마을로 이동합니다.");
                Console.WriteLine();
                Console.ReadKey();
            }

            static void EnterShop(Player player)
            {
                Console.Clear(); //상점
                Console.WriteLine("[상점]\n");
                Console.WriteLine("어서 오십시오 무엇을 구입하시겠습니까?\n");
                Console.WriteLine("1. 나무로 만들어진 무기: G150\n");
                Console.WriteLine("2. 철로 만들어진 무기: G200\n");
                Console.WriteLine();
                Console.ReadKey();
            }

            static void EnterDungeon(Player player)
            {
                Console.Clear(); //던전
                Console.WriteLine("[던전 입장]\n");
                Console.WriteLine("1. 슬라임의 숲\n");
                Console.WriteLine("2. 고블린의 숲\n");
                Console.WriteLine("0. 마을로 돌아가기\n");
                Console.Write("선택: ");


                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("슬라임의 숲으로 이동 중..");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("고블린의 숲으로 이동 중..");
                        Console.ReadKey();
                        break;
                    case "0":
                        Console.WriteLine("\n마을로 돌아가는중..\n");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadKey();
                        break;

                }
            }



        }



    }
}

