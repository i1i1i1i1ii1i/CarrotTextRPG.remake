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
            Console.WriteLine("계단 앞의 석판을 만지자 글씨가 빛납니다.");
            Thread.Sleep(1000);
            Console.WriteLine($"이  름 : {GameManager.Instance.Player.Name}"); 
            Thread.Sleep(150);
            Console.WriteLine($"직  업 : {GameManager.Instance.Player.Class}"); 
            Thread.Sleep(150);
            Console.WriteLine($"레  벨 : {GameManager.Instance.Player.Level}"); 
            Thread.Sleep(150);
            Console.WriteLine($"경험치 : {GameManager.Instance.Player.Exp}/{GameManager.Instance.Player.MaxExp}");
            Thread.Sleep(150);
            Console.WriteLine($"체  력 : {GameManager.Instance.Player.HP}/{GameManager.Instance.Player.MaxHP}"); 
            Thread.Sleep(150);
            Console.WriteLine($"공격력 : {GameManager.Instance.Player.Attack} {(bonusAtk > 0 ? $"(+{bonusAtk})" : "")}"); 
            Thread.Sleep(150);
            Console.WriteLine($"방어력 : {GameManager.Instance.Player.Armor} {(bonusDef > 0 ? $"(+{bonusDef})" : "")}"); 
            Thread.Sleep(150);
            Console.WriteLine($"소지금 : {GameManager.Instance.Player.Gold} G");
            Thread.Sleep(500);

            int dividerY = 30;
            Console.SetCursorPosition(0, dividerY);
            Console.WriteLine(new string('-', Console.WindowWidth));

            Console.SetCursorPosition(0, dividerY+1);
            Console.WriteLine("0. 나가기");
            Thread.Sleep(150);
            Console.WriteLine("1. 인벤토리");

            Console.Write("\n원하시는 행동을 입력해주세요.\n>> ");
            string input = Console.ReadLine();
            if (input == "0") break;
            else if (input == "1") new InventoryScene().LoadScene();
        }
        Console.Clear();
    }
}