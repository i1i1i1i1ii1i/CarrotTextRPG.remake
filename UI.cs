using System;

namespace CarrotTextRPG
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
            Thread.Sleep(1000);
            Console.WriteLine("뜨거운 모래 위에 몸을 뉘인 채, 당신은 천천히 정신을 되찾는다.");
            Thread.Sleep(1000);
            Console.WriteLine("주변을 둘러보지만, 인적은커녕 발자국 하나 보이지 않는다.");
            Thread.Sleep(1000);
            Console.WriteLine("정신은 몽롱하고, 입은 짠 물로 가득 차 있다.");
            Thread.Sleep(1000);
            Console.WriteLine("당신은 온몸이 젖어있는 걸 깨닫는다.");
            Thread.Sleep(1000);
            Console.WriteLine("당신은 누구인가?");
            Thread.Sleep(1000);
            Console.WriteLine("어째서 이 외딴 섬에 홀로 있는 것인가?");
            Thread.Sleep(1000);
            Console.ReadKey();
        }
        public static void CreatCharacter()
        {
            Console.Clear();
            Console.WriteLine("품 안에서 날카로운 것에 긁히는 기분이 들어 옷 속을 살펴보니");
            Thread.Sleep(1000);
            Console.WriteLine("짧은 날붙이 하나와 가죽으로 둘러싸여 있는 책이 한권 나왔다.");
            Thread.Sleep(1000);
            Console.Write("갈색 가죽으로 덮인 책의 오른쪽 구석에 검은색 잉크로 ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("무언가");
            Console.ResetColor();
            Console.WriteLine("가 적혀 있다.");
            Thread.Sleep(1000);
            Console.WriteLine(">> 이름을 입력해주세요.");
            string name = Console.ReadLine();
            Console.WriteLine($"{name}");
            Console.WriteLine("무슨 의미인지는 모르겠지만");
            Thread.Sleep(1000);
            Console.WriteLine("뭔가 입에 익은 느낌이 든다.");
            Thread.Sleep(1000);
            Console.ReadKey();
        }
    }
}
