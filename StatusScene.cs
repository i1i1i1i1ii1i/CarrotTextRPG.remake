using CarrotTextRPG;
using System;

namespace carrotTextRPG;

public class StatusScene : SceneLoader
{
    
    public override void LoadScene()
    { //�÷��̾��� ����â�� ���� �޼����Դϴ�. �κ��丮�� ������ ������ �ɷ�ġ�� �ø� �� ���� Ȯ�� �����մϴ�.
        while (true)
        {
            int bonusAtk = 0;
            int bonusDef = 0;
            if (GameManager.Instance.Player.Inventory != null)
            {
                foreach (var item in GameManager.Instance.Player.Inventory)
                {
                    if (item.Equipped)
                    {
                        bonusAtk += item.Attack;
                        bonusDef += item.Armor;
                   }
               }
            }
            Console.Clear();
            Console.SetCursorPosition(0,2);
            Console.WriteLine("��� ���� ������ ������ �۾��� �����ϴ�.");
            Thread.Sleep(1000);
            Console.WriteLine($"��  �� : {GameManager.Instance.Player.Name}"); 
            Thread.Sleep(150);
            Console.WriteLine($"��  �� : {GameManager.Instance.Player.Class}"); 
            Thread.Sleep(150);
            Console.WriteLine($"��  �� : {GameManager.Instance.Player.Level}"); 
            Thread.Sleep(150);
            Console.WriteLine($"����ġ : {GameManager.Instance.Player.Exp}/{GameManager.Instance.Player.MaxExp}");
            Thread.Sleep(150);
            Console.WriteLine($"ü  �� : {GameManager.Instance.Player.HP}/{GameManager.Instance.Player.MaxHP}"); 
            Thread.Sleep(150);
            Console.WriteLine($"���ݷ� : {GameManager.Instance.Player.Attack} {(bonusAtk > 0 ? $"(+{bonusAtk})" : "")}"); 
            Thread.Sleep(150);
            Console.WriteLine($"���� : {GameManager.Instance.Player.Armor} {(bonusDef > 0 ? $"(+{bonusDef})" : "")}"); 
            Thread.Sleep(150);
            Console.WriteLine($"������ : {GameManager.Instance.Player.Gold} G");
            Thread.Sleep(500);

            int dividerY = 30;
            Console.SetCursorPosition(0, dividerY);
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.SetCursorPosition(0, dividerY+1);
            Console.WriteLine("0. ������");
            Thread.Sleep(150);
            Console.WriteLine("1. �κ��丮");

            Console.Write("\n���Ͻô� �ൿ�� �Է����ּ���.\n>> ");
            string input = Console.ReadLine();
            if (input == "0") break;
            else if (input == "1") new InventoryScene().LoadScene();
        }
        Console.Clear();
    }
}