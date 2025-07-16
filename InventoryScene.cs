using carrotTextRPG;
using CarrotTextRPG;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarrotTextRPG
{
    class InventoryScene : SceneLoader
    {
        List<Item> items = GameManager.Instance.Player.Inventory;
        public override void LoadScene()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                if (items.Count == 0)
                {
                    Console.WriteLine("아이템이 없습니다.\n");
                }
                else
                {
                    Console.WriteLine("[아이템 목록]");
                    int index = 1;
                    foreach (var item in items)
                    {
                        Console.Write("- {0} ", index++);
                        if (item.Equipped) Console.Write("[E]");
                        Console.WriteLine($"{item.Name} | {item.GetStatText()} | {item.Description}");
                    }
                }

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "0") break;
                else if (input == "1") ManageEquip();
            }
            Console.Clear();
        }
        void ManageEquip()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
                if (items.Count == 0)
                {
                    Console.WriteLine("아이템이 없습니다.\n");
                    Console.WriteLine("0. 나가기\n>> ");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.Write("- {0} ", i + 1);
                    if (items[i].Equipped) Console.Write("[E]");
                    Console.WriteLine($"{items[i].Name} | {items[i].GetStatText()} | {items[i].Description}");
                }
                Console.WriteLine("0. 나가기\n>> ");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "0") break;
                if (int.TryParse(input, out int idx) && idx >= 1 && idx <= items.Count)
                {
                    items[idx - 1].Equipped = !items[idx - 1].Equipped;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 엔터를 누르세요.");
                    Console.ReadLine();
                }
            }
        }
    }
}


