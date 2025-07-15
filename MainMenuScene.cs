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

        Player player = new Player();
        player.Name = nameInput;
        Console.WriteLine($"����� ������ �̸��� {player.Name} �Դϴ�.");

        while (true)
        {
            Console.WriteLine("���� ������ ������ �� �ֽ��ϴ�.\n\n0. ���� \n1. ���� ����\n2. ���� ����\n\n���Ͻô� �ൿ�� �Է����ּ���.\n>>");
            string input = Console.ReadLine();
            int inputInt;

            if (int.TryParse(input, out inputInt) == false)
            {
                ShowErrorMsg();
                continue;
            }

            if (inputInt == 0) return;

            else if (inputInt == 1)
            {
                SceneLoader statusScene = new StatusScene();
                statusScene.LoadScene();
            }

            else if (inputInt == 2)
            {
                SceneLoader battleScene = new BattleScene();
                battleScene.LoadScene();
            }
            else ShowErrorMsg();
        }
    }

    private void ShowErrorMsg()
    {
        Console.WriteLine("�߸��� �Է�. �ٽ� �õ��ϼ���.");
    }
}