using System;

namespace carrotTextRPG;

public class StatusScene : SceneLoader
{
    
    public override void LoadScene()
    {
        while (true)
        {
            //int bonusAtk = 0;
            //int bonusDef = 0;
            //if (inventory != null)
            //{
            //    foreach (var item in inventory.items)
            //    {
            //        if (item.Equipped)
            //        {
            //            bonusAtk += item.Attack;
            //            bonusDef += item.Defense;
            //        }
            //    }
            //}
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {GameManager.Instance.Player.Level}");
            Console.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.Class})");
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.Attack}");
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.Armor}");
            Console.WriteLine($"체 력 : {GameManager.Instance.Player.HP}");
            Console.WriteLine($"Gold : {GameManager.Instance.Player.Gold} G\n");
            Console.WriteLine("0. 나가기\n");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();
            if (input == "0") break;
        }
        Console.Clear();
    }
}