using carrotTextRPG;

namespace carrotTextRPG;

class Program
{
    static void Main(string[] args)
    {
<<<<<<< Updated upstream
        //GameManager gameManger = new GameManager();
        //SceneLoader scene = new MainMenuScene();
        //scene.LoadScene();
        Console.SetWindowSize(90, 51);
        Console.SetBufferSize(90, 51);
        
        
        //UI.ShowLOGO();
        UI.NormalScript();


=======
        GameManager gameManger = new GameManager();
        SceneLoader scene = new MainMenuScene();
        scene.LoadScene();
        Console.SetWindowSize(100, 51);
        Console.SetBufferSize(100, 51);
>>>>>>> Stashed changes
        Console.ReadKey();
    }
}
