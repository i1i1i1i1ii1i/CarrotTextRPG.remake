using carrotTextRPG;
using System.Security.Cryptography.X509Certificates;

namespace carrotTextRPG;

class Program
{
    static void Initializer()
    {
        GameManager.Instance.AddItem("수련자 갑옷", 0, 5,"수련에 도움을 주는 갑옷입니다.", 10, "방어", 1000);
        GameManager.Instance.AddItem("무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 15, "방어", 1200);
        GameManager.Instance.AddItem("스파르타의 갑옷", 0, 15, "전설의 갑옷입니다.", 30, "방어", 3500);
        GameManager.Instance.AddItem("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 5, "공격", 600);
        GameManager.Instance.AddItem("청동 도끼", 5, 0, "어디선가 사용됐던 도끼입니다.", 10, "공격", 1500);
        GameManager.Instance.AddItem("스파르타의 창", 7, 0, "전설의 창입니다.", 15, "공격", 3000);
    }
    static void Main(string[] args)
    {
        Initializer();
        GameManager gameManger = new GameManager();
        SceneLoader scene = new MainMenuScene();
        scene.LoadScene();
        Console.SetWindowSize(80, 40);
        Console.SetBufferSize(80, 40);
        Console.ReadKey();

        
    }
}
