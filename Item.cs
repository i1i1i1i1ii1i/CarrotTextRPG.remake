using System;

namespace carrotTextRPG;

//public class Item
//{
//    public string Name { get; set; }
//    public string Type { get; set; }
//    public int BuffValue { get; set; } // �������� �ִ� ȿ��
//    public int itemNum { get; set; }
//}

public struct Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int BuffValue { get; set; }
    public int ItemNumber { get; set; }

    public Item(string name, string type, int buffValue, int itemNumber)
    {
        Name = name; Type = type; BuffValue = buffValue; ItemNumber = itemNumber;
    }
}