using CarrotTextRPG;
using System;

namespace carrotTextRPG;

public class StatusScene : SceneLoader
{
    
    public override void LoadScene()
    { //�÷��̾��� ����â�� ���� �޼����Դϴ�. �κ��丮�� ������ ������ �ɷ�ġ�� �ø� �� ���� Ȯ�� �����մϴ�.
        while (true)
        {
            //int bonusAtk = 0;
            //int bonusDef = 0;

            //if (GameManager.Instance.Player.Inventory != null)
            //{
            //    foreach (var item in GameManager.Instance.Player.Inventory) //�κ��丮�� ����� �������� �������� ���ݷ�, ������ ����
            //    {
            //        if (item.Equipped)
            //        {
            //            if (item.Type == "����") bonusAtk += item.BuffValue;
            //            else bonusDef += item.BuffValue;
            //        }
            //    }
            //}
            Console.Clear();
            Console.WriteLine("���� ����");
            Console.WriteLine("ĳ������ ������ ǥ�õ˴ϴ�.\n");
            Console.WriteLine($"Lv. {GameManager.Instance.Player.Level}");
            Console.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.Class})");
            Console.WriteLine($"���ݷ� : {GameManager.Instance.Player.AttackBoosted}"); //{(bonusAtk > 0 ? $"(+{bonusAtk})" : "")}"); // ���ݷ� ( + )
            Console.WriteLine($"���� : {GameManager.Instance.Player.ArmorBoosted}"); // {(bonusDef > 0 ? $"(+{bonusDef})" : "")}"); // ���� ( + )
            Console.WriteLine($"ü �� : {GameManager.Instance.Player.HP}");
            Console.WriteLine($"Gold : {GameManager.Instance.Player.Gold} G\n");
            Console.WriteLine("0. ������\n");
            Console.WriteLine("1. �κ��丮\n");

            Console.Write("\n���Ͻô� �ൿ�� �Է����ּ���.\n>> ");
            string input = Console.ReadLine();
            if (input == "0") break;
            else if (input == "1") new InventoryScene().LoadScene();
        }
        Console.Clear();
    }
}