using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[System.Serializable]
public class Item
{
    public int id;
    public int num;
    public Item(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
}

public class PlayerInfo
{
    public string name;
    public int atk;
    public int def;
    public float moveSpeed;
    public double roundSpeed;
    public Item weapon;
    public List<int> listInt;
    public List<Item> itemList;
    public Dictionary<int, Item> itemDic;
    public Dictionary<string, Item> itemDic2;
    [SerializeField]
    private int privateI = 1;
    [SerializeField]
    protected int protectedI = 2;
}

public class Lesson1_Exercises : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo p = new PlayerInfo();
        p.name = "Ã∆¿œ ¶";
        p.atk = 11;
        p.def = 5;
        p.moveSpeed = 20.5f;
        p.roundSpeed = 21.4f;
        p.weapon = new Item(1,1);
        p.listInt = new List<int>() { 1, 2, 3, 4, 5 };
        p.itemList = new List<Item>() {new Item (1,99),new Item (2,44) };
        p.itemDic = new Dictionary<int, Item>() { { 1, new Item(1, 12) },{2,new Item(2,22) } };
        p.itemDic2 = new Dictionary<string, Item>() { { "1", new Item(1, 12) }, { "2", new Item(2, 20) } };

        SaveData(p,"PlayerInfo");
        PlayerInfo p2 = LoadData("PlayerInfo");
        print(p2.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveData(PlayerInfo p,string path)
    {
        string str = JsonUtility.ToJson(p);
        File.WriteAllText(Application.persistentDataPath + "/" + path + ".json", str);
    }
    public PlayerInfo LoadData(string path)
    {
        string str = File.ReadAllText(Application.persistentDataPath + "/" + path + ".json");
        PlayerInfo p = JsonUtility.FromJson<PlayerInfo>(str);
        return p;
    }
}
