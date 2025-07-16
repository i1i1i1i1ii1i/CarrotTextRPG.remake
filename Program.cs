using carrotTextRPG;

namespace carrotTextRPG;

class Program
{
    static void Main(string[] args)
    {
        GameManager gameManger = new GameManager();
        SceneLoader scene = new MainMenuScene();
        scene.LoadScene();
        Console.SetWindowSize(80, 40);
        Console.SetBufferSize(80, 40);
        

        Console.ReadKey();
    }
}
