using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace carrotTextRPG;

public class BattleScene : SceneLoader
{
    List<Enemy> EnemyList = new List<Enemy>();
    

    public override void LoadScene()
    {
        bool isMyturn = true;

        Player player = new Player();
        // UI ���ðŰ�
        Console.WriteLine("Battle!");

        // while �� ó���ϰ� 
        Incounter(); // �� �������� �������� ��ī���� ���ְ� ui�� ǥ��

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
        Enemy enemy = new Enemy();

        int incounterNum = random.Next(1, 5);

        for(int i = 0; i< incounterNum; i++)
        {
            int randomMonster = random.Next(0, 4); // << ������ ����Ʈ�� �ε���
            Console.WriteLine(randomMonster); // ����Ʈ �ε����� ���޾ƿͼ� 0 1 2 3;
           // list(i) �� �ش��ϴ� ������ Status �ҷ����� ǥ��
           // Console.WriteLine($"Lv.{enemy.Level} {enemy.Name} {enemy.HP}"); 
        }
    }

    public void Turn()
    {

    }
}