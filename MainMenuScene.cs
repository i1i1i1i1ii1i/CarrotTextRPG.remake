using System;

namespace carrotTextRPG;

public class MainMenuScene : SceneLoader
{
    public override void LoadScene()
    {
        Console.WriteLine("���ĸ�Ÿ ������ ���� ������ ȯ���մϴ�.\n �̸��� �Է��� �ּ���.\n>>");
        string nameInput = Console.ReadLine();

        if (nameInput == null)
        {
            ShowErrorMsg();
            return;
        }

        GameManager.Instance.GeneratePlayer(nameInput);
        Console.WriteLine($"����� ������ �̸��� {GameManager.Instance.Player.Name} �Դϴ�.");

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("���� ������ ������ �� �ֽ��ϴ�.\n\n0. ���� \n1. ���� ����\n2. ���� ����\n");
            Console.Write("\n���Ͻô� �ൿ�� �Է����ּ���.\n >>");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int inputInt))
            {
                ShowErrorMsg(); continue;
            }

            switch (inputInt)
            {
                case 0:
                    isRunning = false; // ���� ����
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
        Console.WriteLine("�߸��� �Է�. �ٽ� �õ��ϼ���.");
    }
}