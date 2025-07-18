using carrotTextRPG;

namespace carrotTextRPG;

class Program
{
    static void Main(string[] args)
    {
        //GameManager gameManger = new GameManager();
        //SceneLoader scene = new MainMenuScene();
        //scene.LoadScene();
        Console.SetWindowSize(90, 51);
        Console.SetBufferSize(90, 51);
        
        
        //UI.ShowLOGO();
        UI.NormalScript();


        Console.ReadKey();
    }
}
