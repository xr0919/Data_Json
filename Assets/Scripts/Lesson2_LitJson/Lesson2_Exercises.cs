using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Item2
{
    public int id;
    public int num;
    public Item2() { }
    public Item2(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}

public class PlayerInfo2
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public double roundSpeed;
    public Item2 weapon;
    public List<int> listInt;
    public List<Item2> itemList;
    public Dictionary<string, Item2> itemDic;
    public Dictionary<string, Item2> itemDic2;
    private int privateI = 1;
    protected int protectedI = 2;
}

public class Lesson2_Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo2 p = new PlayerInfo2();
        p.name = "Ã∆¿œ ¶";
        p.atk = 11;
        p.def = 5;
        p.moveSpeed = 20.5f;
        p.roundSpeed = 21.4f;
        p.weapon = new Item2(1, 1);
        p.listInt = new List<int>() { 1, 2, 3, 4, 5 };
        p.itemList = new List<Item2>() { new Item2(1, 99), new Item2(2, 44) };
        p.itemDic = new Dictionary<string, Item2>() { { "1", new Item2(1, 12) }, { "2", new Item2(2, 22) } };
        p.itemDic2 = new Dictionary<string, Item2>() { { "1", new Item2(1, 12) }, { "2", new Item2(2, 20) } };

        SaveData(p, "PlayerInfo2");
        PlayerInfo2 p2 = LoadData("PlayerInfo2");
        print(p2.name);
    }
    public void SaveData(PlayerInfo2 p, string path)
    {
        string str = JsonMapper.ToJson(p);
        File.WriteAllText(Application.persistentDataPath + "/" + path + ".json", str);
    }
    public PlayerInfo2 LoadData(string path)
    {
        string str = File.ReadAllText(Application.persistentDataPath + "/" + path + ".json");
        PlayerInfo2 p = JsonMapper.ToObject<PlayerInfo2>(str);
        return p;
    }
}
