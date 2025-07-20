using CarrotTextRPG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    int x = Console.WindowWidth, y = Console.WindowHeight; // �ܼ� ������
    bool turn= true; // �÷��̾� ������ �� ������ �����ϴ� ����
    private Player player;
    private List<Enemy> CurrentEnemies;
    private List<Enemy> TotalEnemies;
    Random random = new Random();
    int choice = 0; // �޴� �ε������
    private int dungeonCycle = 0;
    private List<string> options = new List<string> { "����", "������", "����" };

    public BattleScene(Player player)
    {
        this.player = player;
        CurrentEnemies = new List<Enemy>();
        TotalEnemies = new List<Enemy>();
    }

    public override void LoadScene()
    {
        TotalEnemies.Clear();
        CurrentEnemies.Clear();
        Console.Clear();
        Console.CursorVisible = false;
        // UI ���ðŰ�
        Console.WriteLine("Battle!");
        bool isBattle = true; // ��Ʋ�� ���������� Ȯ���ϴ� ����
        int turnCount = 1;
        Console.WriteLine();
        Incounter();


        while (isBattle) // ��Ʋ�� �������� ����
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"�� : {turnCount++}"); // �� �� ǥ��
            
            Display(); // ���� UI ǥ��
            PlayerUI(); // �÷��̾� UI ǥ��

            if (turn) // �÷��̾� ��
            {
                BattleTextUI(); // ����, ������, ���� UI ǥ��
                PlayerAttack();
                RemoveDeadEnemies();
            }
            else // �� ��
            {
                EnemyAttack();
            }

            if (CheckWin())
            {
                Reward();
                Console.WriteLine("�� �� ���� ����ü�� óġ�߽��ϴ�!");
                Thread.Sleep(300);
                GameManager.Instance.dungeonCycle++; // ���� ����Ŭ ����
                Console.WriteLine($"���� ������ {GameManager.Instance.dungeonCycle}ȸ Ŭ���ϼ̽��ϴ�.");
                Console.ReadKey();
                isBattle = false; // ��Ʋ ����
                break;
            }
            else if (CheckLose()) // �й� ���� Ȯ��
            {
                Console.WriteLine("�� ���� �����������ϴ�.");
                Console.ReadKey();
                isBattle = false; // ��Ʋ ����
                new MainMenuScene().MainMenu();
                break;
            }
            else
            {
                turn = !turn; // �� ��ȯ
                Console.ReadKey();
            }
        }
        if (GameManager.Instance.dungeonCycle == 1)
        {
            ChooseClass();
        }

        new MainMenuScene().MainMenu(); // ��Ʋ ���� �� ���� �޴��� �̵�
    }

    public void PlayerUI()
    {
        Console.SetCursorPosition(x - 20, 3 * (y / 4));
        Console.WriteLine($"Lv.{player.Level} {player.Name} ({player.Class})");
        Console.SetCursorPosition(x - 20, (3 * (y / 4)) + 1);
        Console.WriteLine($"HP : {player.HP}");
        Console.SetCursorPosition(0, 3 * (y / 4) + 2);
        Console.WriteLine(new string('-', x));
    }
    public void BattleTextUI()
    {
        int count = options.Count;
        int spacing = x / (count + 1);
        int positionY = y - 6;


        for (int i=0;i<count; i++)
        {
            int positionX = spacing * (i + 1) - (options[i].Length / 2);
            if (positionX<0)
            {
                positionX = 0;
            }

            Console.SetCursorPosition(positionX, positionY);
            Console.Write(options[i]);
        }
        DrawIndicator(choice, spacing, options, positionY);
    }

    public void DrawIndicator(int choice, int spacing, List<string> option, int positionY) // �÷��̾ ������ ���͸� �����ϴ� �ε�������
    {
        while (true)
        {
            int count = option.Count;

            for (int i=0; i < count; i++)
            {
                int clearPositionX = spacing * (i + 1) - 6;
                Console.SetCursorPosition(clearPositionX, positionY);
                Console.Write("    ");
            }

            int drawPositionX = spacing * (choice + 1) - (option[choice].Length / 2) - 3; ; // ������ �ɼ��� ��ġ
            Console.SetCursorPosition(drawPositionX, positionY);
            Console.Write("��"); // �ε������� ǥ��

            var key=Console.ReadKey(intercept: true).Key; // Ű �Է� �ޱ�
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    choice--; // �������� �̵�
                    if (choice < 0) choice = 0; // ���� �ʰ� ����
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    choice++; // ���������� �̵�
                    if (choice >= count) choice = count - 1; // ���� �ʰ� ����
                    break;
                case ConsoleKey.Spacebar:
                    Console.SetCursorPosition(0, positionY);
                    Console.Write(new string(' ', x));
                    switch (choice)
                    {
                        case 0:
                            for (int i=0;i<CurrentEnemies.Count;i++)
                            {
                                Console.SetCursorPosition((i+1)*(x / (CurrentEnemies.Count+1))-5, positionY);
                                if (x > 90) { x -= 2; }
                                Console.Write($"{i+1}{CurrentEnemies[i].Name}");
                            }
                            Console.Write("\n\n\n>>");
                            return;
                        case 1: // ������
                            new InventoryScene().LoadScene(); // �κ��丮 ������ �̵�
                            continue;
                        case 2: // ����
                            Console.WriteLine("���� ����!");
                            Console.ReadKey();
                            new MainMenuScene().MainMenu();
                            return; // ��Ʋ ����
                    }
                    break;
            }
        }
    }


    public void Incounter() // ���� ���� ��ī���� 
    {
        int incounterNum = random.Next(1, 5); // 1���� 4����� �ʿ��Ѹ�ŭ ���� ����

        for (int i = 0; i < incounterNum; i++)
        {
            int randomMonster = random.Next(0, GameManager.Instance.Enemies.Count); // ������ �ִ� ���� ���ο��� ������ ��������

            Enemy template = GameManager.Instance.Enemies[randomMonster];
            CurrentEnemies.Add(template.Clone());  // ���ӿ� ���� ���͵� ����Ʈ
        }
    }

    public void Display() // �ӽ� uió�� �ּ� ó���ϼŵ��˴ϴ�.
    {
        int count = CurrentEnemies.Count;
        if (count==0)
        {
            return;
        }
        int spacing = x / (count + 1); // ���� ���� ���� ���� ����
        int nameLine = y / 4;
        int hpLine = nameLine + 1;

        for(int i=0; i<count; i++)
        {
            var enemy = CurrentEnemies[i];
            int positionX = spacing * (i + 1) - (enemy.Name.Length / 2); // ���� �̸��� ���̿� ���� ��ġ ����
            if (positionX < 0) positionX = 0; // ��ġ�� ������ ������ ��� ����

            Console.SetCursorPosition(positionX, nameLine);
            Console.WriteLine(enemy.Name); // ���� �̸� ���

            Console.SetCursorPosition(positionX, hpLine);
            Console.WriteLine($"HP : {enemy.HP}"); // ���� HP ���
        }
        Console.SetCursorPosition(0, hpLine+2); // Ŀ�� ��ġ �ʱ�ȭ
        Console.WriteLine();
    }

    private void PlayerAttack()
    {
        string attack = Console.ReadLine(); // �÷��̾ ������ ����ü ��ȣ
        int select;
        Random random = new Random();
        int critical = random.Next(0, 101);

        if (!int.TryParse(attack, out select)) // ���ڸ� ������ �ְ�, �Է¹��� ���ڸ� Select�� ����
        {
            Console.WriteLine("���� ��Ȯ�� ����ּ���.");
            return;
        }

        if (select <= CurrentEnemies.Count && select > 0) // Select ���� ���ų� 0 ���� ����
        {
            if (critical <= player.Critical)
            {
                CurrentEnemies[select - 1].HP -= (player.AttackBoosted * 160) / 100; // ũ��Ƽ��
                Console.WriteLine("ũ��Ƽ��!");
            }
            else
            {
                CurrentEnemies[select - 1].HP -= player.AttackBoosted; // ���� ������ enemy�� hp�� �÷��̾��� ���ݷ����� ��´�
            }

            Console.WriteLine($"\n{CurrentEnemies[select - 1].Name} : {CurrentEnemies[select - 1].HP}"); // �ּ� ���� 
        }
        else
        {
            Console.WriteLine("���� ��Ȯ�� ����ּ���."); // ���ܷ� �ٸ� ��ȣ �Է��ҽ�
            return;
        }
    }



    private void EnemyAttack() // ���⼭�� �������� ����
    {
        foreach (var attack in CurrentEnemies) // 
        {
            int dotge = random.Next(0, 101);

            Console.WriteLine($"{attack.Name}�� ����!");
            if (player.Dodge >= dotge)
            {
                Console.WriteLine("\n���� ������ ȸ���߽��ϴ�.");
            }
            else
            {
                if (attack.HP > 0)
                {
                    Console.WriteLine($"{attack.Attack}�� ���ظ� �Ծ���!");
                    player.HP -= attack.Attack;
                }
            }
        }
        Console.WriteLine($"���� ü�� : {player.HP}");
    }

    private void Reward()
    {
        for (int i = 0; i < TotalEnemies.Count; i++)
        {
            player.GainExp(TotalEnemies[i].RwdExp);
            player.Gold += TotalEnemies[i].Gold;
        }
    }
    private bool CheckWin() // ��� ���� HP�� 0 �����̸� true�� ��ȯ
    {

        return CurrentEnemies.All(e => e.HP <= 0);
    }
    private bool CheckLose() // �÷��̾��� ü���� 0 �����̸� true ��ȯ
    {
        return player.HP <= 0;
    }

    private void DrawOption()
    {
        int count= options.Count;
        int spacing = x / (count + 1);
        int positionY = y - 6;
        for (int i = 0; i < count; i++)
        {
            int positionX = spacing * (i + 1) - (options[i].Length / 2);
            if (positionX < 0)
            {
                positionX = 0;
            }
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(options[i]);
        }
    }

    public void ChooseClass()
    {
        Console.Clear();
        Console.WriteLine("����� �� ���� �������� �� �տ� �ϳ��� ������ �ִ�.");
        Thread.Sleep(500);
        Console.WriteLine("���ǿ��� �� �� ���� ���ڰ� ������ �ִ�.");
        Thread.Sleep(500);
        Console.WriteLine("���ǿ� ���� ����, �� �տ� ���ڰ� ��������.");
        Thread.Sleep(500);

        string[] jobLines = {
                " 1  2  3",
                "�� �� ��",
                "        ��",
                "�� �� ��"
            };

        foreach (string line in jobLines)
        {
            WriteCentered(line);
            Thread.Sleep(300);
        }
        Console.WriteLine("������ �������ּ���.");
        Console.Write(">>>"); // ���� ������ DB�� ����Ǿ��ִ� �÷��̾��� �������� ����
        int? job = int.Parse(Console.ReadLine());
        switch (job)
        {
            case 1:
                Console.WriteLine("���簡 ���õǾ����ϴ�.");
                GameManager.Instance.Player.Class = "����";
                GameManager.Instance.Player.Armor += 5; // ���� ������ ���� �������ͽ� ����
                Thread.Sleep(1000);
                Console.WriteLine("���� ��ȭ�� �Ͼ�ϴ�.");
                break;
            case 2:
                Console.WriteLine("�ü��� ���õǾ����ϴ�.");
                GameManager.Instance.Player.Class = "�ü�";
                GameManager.Instance.Player.Critical += 5; // �ü� ������ ���� �������ͽ� ����
                Thread.Sleep(1000);
                Console.WriteLine("���� ��ȭ�� �Ͼ�ϴ�.");
                break;
            case 3:
                Console.WriteLine("�����簡 ���õǾ����ϴ�.");
                GameManager.Instance.Player.Class = "������";
                GameManager.Instance.Player.Attack += 5; // ������ ������ ���� �������ͽ� ����
                Thread.Sleep(1000);
                Console.WriteLine("���� ��ȭ�� �Ͼ�ϴ�.");
                break;
            default:
                Console.WriteLine("������ �������� �ʾҽ��ϴ�.");
                Thread.Sleep(1000);
                Console.WriteLine("���� �ƹ��� ��ȭ�� �Ͼ�� �ʽ��ϴ�.");
                break;

        }

        Console.ReadKey();
    }

    private static void WriteCentered(string text) // �ؽ�Ʈ ��� ����
    {
        int width = Console.WindowWidth;
        int pad = (width - text.Length) / 2;
        if (pad < 0) pad = 0;
        Console.WriteLine(new string(' ', pad) + text);
    }



    private void RemoveDeadEnemies()
    {
        // �̹� �Ͽ� ���� ������ ã��
        var defeatedThisTurn = CurrentEnemies.Where(e => e.HP <= 0).ToList();

        foreach (var deadEnemy in defeatedThisTurn)
        {
            Console.WriteLine($"{deadEnemy.Name}��(��) óġ�߽��ϴ�!");
            TotalEnemies.Add(deadEnemy); // ���� ����� ���� totalEnemies ����Ʈ�� �߰�
        }

        // CurrentEnemies ����Ʈ���� HP�� 0 ������ ��� ���� ����
        CurrentEnemies.RemoveAll(enemy => enemy.HP <= 0);
    }
}