using carrotTextRPG;
using System;
using System.Numerics;

namespace CarrotTextRPG
{
    public class ShopScene : SceneLoader
    {
        List<Item> shopItems = GameManager.Instance.Items;

        public override void LoadScene()
        {
            shopItems.Add(new Item("수련자 갑옷", 0, 5, "수련에 도움을 주는 갑옷입니다.", 1000));
            shopItems.Add(new Item("무쇠갑옷", 0, 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 1200));
            shopItems.Add(new Item("스파르타의 갑옷", 0, 15, "전설의 갑옷입니다.", 3500));
            shopItems.Add(new Item("개발자 셔츠", 0, 9999, "집에 가지 못한 개발자의 땀내나는 셔츠입니다.", 99999));
            shopItems.Add(new Item("낡은 검", 2, 0, "쉽게 볼 수 있는 낡은 검입니다.", 600));
            shopItems.Add(new Item("청동 도끼", 5, 0, "어디선가 사용됐던 도끼입니다.", 1500));
            shopItems.Add(new Item("스파르타의 창", 7, 0, "전설의 창입니다.", 3000));
            shopItems.Add(new Item("개발자의 무기", 9999, 0, "개발자만이 사용할 수 있는 금지된 무기입니다.", 99999));
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드] {GameManager.Instance.Player.Gold} G\n");

                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < shopItems.Count; i++)
                {
                    var item = shopItems[i];
                    Console.WriteLine($"- {i + 1} {item.Name} | {item.GetStatText()} | {item.Description} | {(item.Purchased ? "구매완료" : item.Price + " G")}");
                }

                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "0") break;
                else if (input == "1") BuyItem();
                else if (input == "2") SellItem();
            }
            Console.Clear();
        }

        void BuyItem() //아이템을 사서 인벤토리에 저장하는 메서드입니다.
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유 골드] {GameManager.Instance.Player.Gold} G\n");

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < shopItems.Count; i++)
            {
                var item = shopItems[i];
                Console.WriteLine($"- {i + 1} {item.Name} | {item.GetStatText()} | {item.Description} | {(item.Purchased ? "구매완료" : item.Price + " G")}");
            }
            Console.WriteLine("0. 나가기\n>> ");
            Console.Write("구매할 아이템 번호를 입력하세요: ");
            string input = Console.ReadLine();

            if (input == "0") return;
            if (int.TryParse(input, out int idx) && idx >= 1 && idx <= shopItems.Count)
            {
                var item = shopItems[idx - 1];
                if (item.Purchased)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (GameManager.Instance.Player.Gold >= item.Price)
                {
                    GameManager.Instance.Player.Gold -= item.Price;
                    item.Purchased = true;
                    GameManager.Instance.Player.Inventory.Add(new Item(item.Name, item.Attack, item.Armor, item.Description, item.Price, true));
                    Console.WriteLine("구매를 완료했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            Console.WriteLine("엔터를 누르면 돌아갑니다.");
            Console.ReadLine();
        }

        void SellItem() //BuyItem()메서드를 통해 구매한 아이템을 파는 메서드입니다. 인벤토리와 연결되어 있습니다.
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine($"[보유 골드] {GameManager.Instance.Player.Gold} G\n");

            var inventory = GameManager.Instance.Player.Inventory;

            if (inventory.Count == 0)
            {
                Console.WriteLine("판매할 아이템이 없습니다.\n");
                Console.Write("0. 나가기\n>> ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inventory.Count; i++)
            {
                var item = inventory[i];
                Console.Write($"- {i + 1}. ");
                if (item.Equipped) Console.Write("[E]");
                Console.WriteLine($"{item.Name} | {item.GetStatText()} | {item.Description}");
            }

            Console.WriteLine("\n0. 나가기");
            Console.Write("\n판매할 아이템 번호를 선택해주세요\n>> ");
            string input = Console.ReadLine();

            if (input == "0") return;

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > inventory.Count)
            {
                Console.WriteLine("\n잘못된 입력입니다. 계속하려면 Enter를 누르세요...");
                Console.ReadLine();
                return;
            }

            var selectedItem = inventory[choice - 1];

            if (selectedItem.Equipped)
            {
                Console.WriteLine("\n장착 중인 아이템은 판매할 수 없습니다.");
                Console.WriteLine("계속하려면 Enter를 누르세요...");
                Console.ReadLine();
                return;
            }

            int sellPrice = (int)(selectedItem.Price * 0.85);
            GameManager.Instance.Player.Gold += sellPrice;
            inventory.RemoveAt(choice - 1);

            Console.WriteLine($"\n{selectedItem.Name}을(를) {sellPrice} G에 판매했습니다.");
            Console.WriteLine("계속하려면 Enter를 누르세요...");
            Console.ReadLine();
        }
    }
}
