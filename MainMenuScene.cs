using System;

namespace carrotTextRPG;

public class MainMenuScene : SceneLoader
{
    public override void LoadScene()
    {
        Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.\n 이름을 입력해 주세요.\n>>");
        string nameInput = Console.ReadLine();

        if (nameInput == null)
        {
            ShowErrorMsg();
            return;
        }

        GameManager.Instance.GeneratePlayer(nameInput);
        Console.WriteLine($"당신이 설정한 이름은 {GameManager.Instance.Player.Name} 입니다.");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("이제 전투를 시작할 수 있습니다.\n\n0. 종료 \n1. 상태 보기\n2. 전투 시작\n");
            Console.Write("\n원하시는 행동을 입력해주세요.\n >>");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int inputInt))
            {
                ShowErrorMsg(); continue;
            }

            switch (inputInt)
            {
                case 0:
                    isRunning = false; // 루프 종료
                    break;
                case 1:
                    new StatusScene().LoadScene();
                    break;
                case 2:
                    new BattleScene().LoadScene();
                    break;
                default:
                    ShowErrorMsg(); break;
            }
            //if (int.TryParse(input, out inputInt) == false)
            //{
            //    ShowErrorMsg();
            //    continue;
            //}

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
        }
    }

    private void ShowErrorMsg()
    {
        Console.WriteLine("잘못된 입력. 다시 시도하세요.");
    }
}