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
            while (true) // 상점 메인 페이지 입니다. while 반복문을 통해 리스트로 아이템을 출력하고 "구매" "판매"를 선택할 수 있습니다.
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
                Console.WriteLine($"[보유 골드] {GameManager.Instance.Player.Gold} G\n");

                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < shopItems.Count; i++)
                {
                    var item = shopItems[i]; //shopItem[i]번째의 변수를 item
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
                var item = shopItems[i]; // i번째 아이템을 item 변수로 가져옵니다.
                Console.WriteLine($"- {i + 1} {item.Name} | {item.GetStatText()} | {item.Description} | {(item.Purchased ? "구매완료" : item.Price + " G")}"); 
                // Item.Name과 GetStatText()는 공격력,방어력값이 각각 저장되어 있는데 예를 들어 방어 아이템이면 공격력은 0, 방어력은 0보다 큰 숫자를 통해 얼마큼 올랐는지 return값을 받습니다.
            }
            Console.WriteLine("0. 나가기\n>> ");
            Console.Write("구매할 아이템 번호를 입력하세요: ");
            string input = Console.ReadLine();

            if (input == "0") return;
            if (int.TryParse(input, out int idx) && idx >= 1 && idx <= shopItems.Count)// TryParse 문으로 string 값을 int값으로 변환시킨 다음 아이템 리스트에 1부터 n번까지의 리스트를 출력합니다.
            {
                var item = shopItems[idx - 1]; //idx-1을 하는 이유는 리스트의 첫 번째 값이 0부터 시작하기 때문입니다. 받는 값이 예를 들어 1. 아이템[1] 이런 식이면 리스트에서는 [0]번째.
                if (item.Purchased)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else if (GameManager.Instance.Player.Gold >= item.Price) //필요 골드보다 플레이어의 골드가 크면 아이템 구매할 수 있습니다.
                {
                    GameManager.Instance.Player.Gold -= item.Price;
                    item.Purchased = true;
                    GameManager.Instance.Player.Inventory.Add(new Item(item.Name, item.Attack, item.Armor, item.Type, item.Description,item.Price, true));
                    Console.WriteLine("구매를 완료했습니다."); //인벤토리 리스트 안에 구매한 아이템 변수를 집어넣습니다.
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

            var inventory = GameManager.Instance.Player.Inventory; //인벤토리에 저장된 아이템을 inventory 변수에 넣습니다.

            if (inventory.Count == 0)
            {
                Console.WriteLine("판매할 아이템이 없습니다.\n"); //아이템을 구매하지 않았거나 판매했으면 출력됩니다.
                Console.Write("0. 나가기\n>> ");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inventory.Count; i++)
            {
                var item = inventory[i]; //93번에서 생성한 i 번째의 inventory의 값을 또 다시 item에 넣습니다.
                Console.Write($"- {i + 1}. "); // 몇 번째 item인지 출력
                if (item.Equipped) Console.Write("[E]"); //장착된 아이템이면 [E]를 출력합니다.
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

            var selectedItem = inventory[choice - 1]; //입력받은 input값을 choice로 변환한 뒤 choice-1번째 해당하는 인벤토리 아이템을 selectedItem 변수에 넣습니다.

            if (selectedItem.Equipped)
            {
                Console.WriteLine("\n장착 중인 아이템은 판매할 수 없습니다."); //장착된 아이템을 판매할 수 없음
                Console.WriteLine("계속하려면 Enter를 누르세요...");
                Console.ReadLine();
                return;
            }

            int sellPrice = (int)(selectedItem.Price * 0.85); //구매한 아이템을 판매하면 원가 * 0.85 값으로 재판매 가능
            GameManager.Instance.Player.Gold += sellPrice;
            inventory.RemoveAt(choice - 1);
            var shopItem = shopItems.Find(x => x.Name == selectedItem.Name); //"구매완료" 였던 아이템을 다시 false값으로 재설정
            if (shopItem != null)
            {
                shopItem.Purchased = false; //이로써 "구매완료"가 True 였던 값이 false로 바뀌어 다시 구매 가능합니다.
            }
            Console.WriteLine($"\n{selectedItem.Name}을(를) {sellPrice} G에 판매했습니다.");
            Console.WriteLine("계속하려면 Enter를 누르세요...");
            Console.ReadLine();
        }
    }
}
