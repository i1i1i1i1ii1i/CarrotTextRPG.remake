using CarrotTextRPG;
using System;

namespace carrotTextRPG;

public class StatusScene : SceneLoader
{
    
    public override void LoadScene()
    { //플레이어의 상태창을 보는 메서드입니다. 인벤토리에 장착된 아이템 능력치가 올린 것 또한 확인 가능합니다.
        while (true)
        {
            int bonusAtk = 0;
            int bonusDef = 0;
            if (GameManager.Instance.Player.Inventory != null)
            {
                foreach (var item in GameManager.Instance.Player.Inventory) //인벤토리와 연결된 아이템을 장착했을 공격력, 방어력이 증가
                {
                    if (item.Equipped)
                    {
                        bonusAtk += item.Attack; //공격력이 몇만큼 증가되었는지 기존 공격력에 더해서 출력
                        bonusDef += item.Armor; // 방어력이 몇만큼 증가되었는지 기존 방어력에 더해서 출력
                   }
               }
            }
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. {GameManager.Instance.Player.Level}");
            Console.WriteLine($"{GameManager.Instance.Player.Name} ({GameManager.Instance.Player.Class})");
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.Attack + bonusAtk} {(bonusAtk > 0 ? $"(+{bonusAtk})" : "")}"); // 공격력 ( + )
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.Armor + bonusDef} {(bonusDef > 0 ? $"(+{bonusDef})" : "")}"); // 방어력 ( + )
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