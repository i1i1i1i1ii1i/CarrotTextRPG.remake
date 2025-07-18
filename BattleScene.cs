using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    private Player player;
    private List<Enemy> TotalEnemies;
    private List<Enemy> CurrentEnemies;

    
    
    public BattleScene(Player player)
    {
        this.player = player;
        TotalEnemies = new List<Enemy>();
        CurrentEnemies = new List<Enemy>();

        EnemyInit();
    }

    public override void LoadScene()
    {
        Console.Clear();


        // UI ���ðŰ�
        Console.WriteLine("Battle!");
        Console.WriteLine();
        Incounter(); // �� �������� �������� ��ī���� ���ְ� ui�� ǥ��
        Display();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("[������]");
        Console.WriteLine($"Lv.{player.Level} {player.Name} {player.Class}");
        Console.WriteLine($"{player.HP}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("1. ����");
        Console.WriteLine();
        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���");
        Console.WriteLine(">>");
        // while�� ���ϵ�

       while(true) // �ӽ�
        {
            PlayerAttack();

            EnemyAttack();

        }
    }


    public void Incounter() // ���� ���� ��ī���� 
    {
        Random random = new Random();

        int incounterNum = random.Next(1, 5); // 1���� 4����� �ʿ��Ѹ�ŭ ���� ����

        for(int i = 0; i< incounterNum; i++)
        {
            int randomMonster = random.Next(0, TotalEnemies.Count); // ������ �ִ� ���� ���ο��� ������ ��������
            CurrentEnemies.Add(TotalEnemies[randomMonster]);  // ���ӿ� ���� ���͵� ����Ʈ
        }
    }

    public void Display() // �ӽ� uió�� �ּ� ó���ϼŵ��˴ϴ�.
    {
        foreach(var enemy in CurrentEnemies)
        {
            Console.Write($"{enemy.Name} / {enemy.Attack} \t");
        }
        Console.WriteLine();
        foreach (var enemy in CurrentEnemies)
        {
            Console.Write($"   {enemy.HP}   ");
        }
    }

    private void PlayerAttack()
    {
        string attack = Console.ReadLine(); // �÷��̾ ������ ����ü ��ȣ
        int select;

        if (!int.TryParse(attack, out select)) // ���ڸ� ������ �ְ�, �Է¹��� ���ڸ� Select�� ����
        {
            Console.WriteLine("���ڸ� �Է��ض� ����;");
        }

        if (select <= CurrentEnemies.Count && select > 0) // Select ���� ���ų� 0 ���� ����
        {
            CurrentEnemies[select - 1].HP -= player.Attack; // ���� ������ enemy�� hp�� �÷��̾��� ���ݷ����� ��´�
            Console.WriteLine($"{CurrentEnemies[select - 1].Name} : {CurrentEnemies[select - 1].HP}"); // �ּ� ���� 
        }
        else
        {
            Console.WriteLine("�ִ� �ֵ� ��ȣ�� �Է����ּ���"); // ���ܷ� �ٸ� ��ȣ �Է��ҽ�
        }
    }

    private void EnemyAttack() // ���⼭�� �������� ����
    {
        foreach(var attack in CurrentEnemies) // 
        {
            player.HP -= attack.Attack;
        }
        Console.WriteLine($"���� ü�� : {player.HP}");
    }


    private void EnemyInit() // ���� ��ü, �ʿ��� ���� ������ ���⿡ �߰�, �̸� ü�� ���ݷ� ���� ����
    {
        TotalEnemies.Add(new Enemy("���", 50, 5));
        TotalEnemies.Add(new Enemy("����", 40, 3));
        TotalEnemies.Add(new Enemy("�ܰ����ü", 30, 4));
        TotalEnemies.Add(new Enemy("��", 20, 1));

    }
    private void RemoveDeadEnemies() // ����Ʈ���� �ǰ� 0 ���Ϸ� �������� ����
    {
        CurrentEnemies.RemoveAll(enemy => enemy.HP <= 0);
    }
}