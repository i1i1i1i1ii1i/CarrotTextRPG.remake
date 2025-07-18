using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    private Player player;
    private List<Enemy> CurrentEnemies;
    
    public BattleScene(Player player)
    {
        this.player = player;
        CurrentEnemies = new List<Enemy>();
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
            int randomMonster = random.Next(0, GameManager.Instance.Enemies.Count); // ������ �ִ� ���� ���ο��� ������ ��������
            CurrentEnemies.Add(GameManager.Instance.Enemies[randomMonster]);  // ���ӿ� ���� ���͵� ����Ʈ
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
        Random random = new Random();
        int critical = random.Next(0, 101);

        if (!int.TryParse(attack, out select)) // ���ڸ� ������ �ְ�, �Է¹��� ���ڸ� Select�� ����
        {
            Console.WriteLine("���ڸ� �Է��ض� ����;");
        }

        if (select <= CurrentEnemies.Count && select > 0) // Select ���� ���ų� 0 ���� ����
        {
            if (critical <= player.Critical)
            {
                CurrentEnemies[select - 1].HP = (player.Attack * 160) / 100; // ũ��Ƽ��
                Console.WriteLine("ũ��Ƽ��!");
            }
            else
            {
                CurrentEnemies[select - 1].HP -= player.Attack; // ���� ������ enemy�� hp�� �÷��̾��� ���ݷ����� ��´�
            }

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
            Random random = new Random();
            int dotge = random.Next(0, 101);
            if(player.Dodge >= dotge)
            {
                Console.WriteLine("��������~");
            }
            else
            {
               player.HP -= attack.Attack;
            }
        }
        Console.WriteLine($"���� ü�� : {player.HP}");
    }


    
    private void RemoveDeadEnemies() // ����Ʈ���� �ǰ� 0 ���Ϸ� �������� ����
    {
        CurrentEnemies.RemoveAll(enemy => enemy.HP <= 0);
    }
}