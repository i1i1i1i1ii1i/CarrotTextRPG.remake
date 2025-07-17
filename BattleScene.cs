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

        bool isMyturn = true;

        // UI ���ðŰ�
        Console.WriteLine("Battle!");
        
        // while �� ó���ϰ� 
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

        if(isMyturn)
        {
            string PlayerAction = Console.ReadLine(); // �÷��̾��� �ൿ�� int ������ �޴´�.



            if (PlayerAction != "1") // ��� ����ó��
            {
                Console.WriteLine("�޴��� �ִ� ���ڸ� �Է����ּ���");
            }

            switch (PlayerAction)
            {
                case "1":
                    // enemy.hp - plyaer.attack ���� ����
                    isMyturn = false;
                    // loadscene
                    break;
            }
        }

        if(!isMyturn)
        {
            // ���⼭ ���Ͱ� �����ҵ�

            // player�� ����
        }

       



        //�ʿ��Ѱ�
        //�ٷ� ����
        // ������
        // w�θ� ����
        // ���°�, ���� ��ī����
        // ����  ����
        // ����  ����
        // ����  ����
        // ����  ����
        // ����  ����
        // ����������

    }


    public void Incounter() // ���� ���� ��ī���� 
    {
        Random random = new Random();

        int incounterNum = random.Next(1, 5);

        for(int i = 0; i< incounterNum; i++)
        {
            int randomMonster = random.Next(0, TotalEnemies.Count); // << ������ ����Ʈ�� �ε���
            CurrentEnemies.Add(TotalEnemies[randomMonster]);
        }
    }

    public void Display()
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

    public void AttackEnemy()
    {

    }

    public void TakeDamage()
    {

    }

    public void Turn()
    {

    }

    private void EnemyInit()
    {
        TotalEnemies.Add(new Enemy("���", 50, 5));
        TotalEnemies.Add(new Enemy("����", 40, 3));
        TotalEnemies.Add(new Enemy("�ܰ����ü", 30, 4));
        TotalEnemies.Add(new Enemy("��", 20, 1));
    }
}