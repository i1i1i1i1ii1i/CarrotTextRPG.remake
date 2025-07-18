using CarrotTextRPG;
using System;

namespace carrotTextRPG;

public class StatusScene : SceneLoader
{
    
    public override void LoadScene()
    { //플레이어의 상태창을 보는 메서드입니다. 인벤토리에 장착된 아이템 능력치가 올린 것 또한 확인 가능합니다.
        while (true)
        {
            //int bonusAtk = 0;
            //int bonusDef = 0;

            //if (GameManager.Instance.Player.Inventory != null)
            //{
            //    foreach (var item in GameManager.Instance.Player.Inventory) //인벤토리와 연결된 아이템을 장착했을 공격력, 방어력이 증가
            //    {
            //        if (item.Equipped)
            //        {
            //            if (item.Type == "공격") bonusAtk += item.BuffValue;
            //            else bonusDef += item.BuffValue;
            //        }
            //    }
            //}
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {GameManager.Instance.Player.Level}");
            Console.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.Class})");
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.AttackBoosted}"); //{(bonusAtk > 0 ? $"(+{bonusAtk})" : "")}"); // 공격력 ( + )
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.ArmorBoosted}"); // {(bonusDef > 0 ? $"(+{bonusDef})" : "")}"); // 방어력 ( + )
            Console.WriteLine($"체 력 : {GameManager.Instance.Player.HP}");
            Console.WriteLine($"Gold : {GameManager.Instance.Player.Gold} G\n");
            Console.WriteLine("0. 나가기\n");
            Console.WriteLine("1. 인벤토리\n");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();
            if (input == "0") break;
            else if (input == "1") new InventoryScene().LoadScene();
        }
        Console.Clear();
    }
}