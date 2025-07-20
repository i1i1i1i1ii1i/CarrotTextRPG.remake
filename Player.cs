using System;
using System.Net.Security;

namespace carrotTextRPG;

public class Player
{
    public string Name { get; set; }
    public int Level { get; set; }
    public float Exp { get; set; }
    public string Class { get; set; }
    public int Attack { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Armor { get; set; }
    public int Gold { get; set; }
    public int Critical { get; set; }
    public int Dodge { get; set; }
    public List<Item> Inventory { get; set; }

    public float MaxExp // �ִ� ����ġ ����
    { 
        get
        {
            return 100 + (Level - 1.1f);
        } 
    }

    public int AttackBoosted
    {
        get
        {
            int value = 0;

            foreach (var item in Inventory)
            {
                if (item.Equipped && item.Type == "����") value += item.Attack;
            }
            return Attack + value;
        }
    }

    public int ArmorBoosted
    {
        get
        {
            int value = 0;

            foreach (var item in Inventory)
            {
                if (item.Equipped && item.Type == "���") value += item.Armor;

            }
            return Armor + value;
        }
    }

    public void GainExp(float expAmount) // ����ġ ȹ��
    {
        Exp += expAmount;

        while (Exp >= MaxExp)
        {
            Exp -= MaxExp;
            LevelUp();
        }
    }

    private void LevelUp() // ������
    {
        Level++;
        
        switch (Class)
        {
            case "ǥ����" : 
                MaxHP += 5;
                HP = MaxHP;
                Attack += 2;
                Armor += 2;
                Critical += 1;
                Dodge += 1;
                break;
            case "����" : 
                MaxHP += 10;
                HP = MaxHP;
                Attack += 5;
                Armor += 5;
                Critical += 1;
                Dodge += 1;
                break;
            case "�ü�" : 
                MaxHP += 5;
                HP = MaxHP;
                Attack += 5;
                Armor += 1;
                Critical += 5;
                Dodge += 10;
                break;
            case "������" : 
                MaxHP += 1;
                HP = MaxHP;
                Attack += 20;
                Armor += 1;
                Critical += 1;
                Dodge += 1;
                break;
        }
    }
}

