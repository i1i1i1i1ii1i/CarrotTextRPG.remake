using carrotTextRPG;
using System.Security.Cryptography.X509Certificates;

namespace carrotTextRPG;

class Program
{
    static void InitializeItems()
    {
        GameManager.Instance.AddItem("수련자 갑옷", 0, 5, "방어", "수련에 도움을 주는 갑옷입니다.", 1000);
        GameManager.Instance.AddItem("무쇠갑옷", 0, 9, "방어", "무쇠로 만들어져 튼튼한 갑옷입니다.", 1200);
        GameManager.Instance.AddItem("스파르타의 갑옷", 0, 15, "방어", "전설의 갑옷입니다.", 3500);
        GameManager.Instance.AddItem("낡은 검", 2, 0, "공격","쉽게 볼 수 있는 낡은 검입니다.", 600);
        GameManager.Instance.AddItem("청동 도끼", 5, 0, "공격","어디선가 사용됐던 도끼입니다.", 1500);
        GameManager.Instance.AddItem("스파르타의 창", 7, 0, "공격", "전설의 창입니다.", 3000);
    }
    static void Main(string[] args)
    {
        InitializeItems();
        GameManager gameManger = new GameManager();
        SceneLoader scene = new MainMenuScene();
        scene.LoadScene();
        Console.SetWindowSize(100, 51);
        Console.SetBufferSize(100, 51);
}
