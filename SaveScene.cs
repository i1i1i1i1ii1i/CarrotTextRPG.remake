using carrotTextRPG;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarrotTextRPG
{
    class SaveScene : SceneLoader
    {
        private string FilePath = "../../../PlayerData.json"; // 상대경로 (동일하게 맞춤)

        public override void LoadScene()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("저장하기");
                Console.WriteLine("지금까지의 데이터를 저장하거나 불러옵니다.\n");

                Console.WriteLine("1. 저장하기");
                Console.WriteLine("2. 불러오기");
                Console.WriteLine("0. 나가기\n");

                Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                string input = Console.ReadLine();

                if (input == "0") break;
                else if (input == "1")
                {
                    SaveData(GameManager.Instance.Player);
                    Console.WriteLine("저장 완료! 계속하려면 Enter...");
                    Console.ReadLine();
                }
                else if (input == "2")
                {
                    var loadedPlayer = LoadData();
                    if (loadedPlayer != null)
                    {
                        GameManager.Instance.Player = loadedPlayer;
                        Console.WriteLine("불러오기 완료! 계속하려면 Enter...");
                    }
                    else
                    {
                        Console.WriteLine("불러오기 실패! 계속하려면 Enter...");
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. Enter를 눌러 계속하세요...");
                    Console.ReadLine();
                }
            }
        }

        public void SaveData(Player player)
        {
            try
            {
                string json = JsonConvert.SerializeObject(player, Formatting.Indented);
                File.WriteAllText(FilePath, json);
                DateTime dateTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public Player LoadData()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string json = File.ReadAllText(FilePath);
                    return JsonConvert.DeserializeObject<Player>(json);
                }
                else
                {
                    Console.WriteLine("저장된 데이터가 없습니다.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return null;
            }
        }
    }
}
