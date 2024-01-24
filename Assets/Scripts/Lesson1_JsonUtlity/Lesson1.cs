using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

[System.Serializable]
public class Student
{
    public int age;
    public string name;

    public Student(int age,string name) {
        this.age = age;
        this.name = name;   
    }
}
//最外面的类不用加[System.Serializable] 但是如果包含了别的自定义类就要
public class MrTang
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<int, string> dic;
    public Dictionary<string, string> dic2;

    public Student s1;
    public List<Student> s2s;

    //想要序列化私有变量
    [SerializeField]
    private int privateI = 1;
    [SerializeField]
    protected int protectedI = 2;
}

[System.Serializable]
public class RoleInfo
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}

public class RoleData
{
    public List<RoleInfo> list;
}
public class Lesson1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //JsonUtlity Unity自带用于解释Json的公共类

        //在文件中存读字符串
        //1.存储字符串到自定路径文件中
        //-1第一个参数 存储的路径 一定要保证文件夹是存在的 "/Json/Test.json"其中没有Json文件夹会报错
        //-2第二个参数 存储的字符串内容
        File.WriteAllText(Application.persistentDataPath + "/Test.json", "存储的json文件");
        print(Application.persistentDataPath);
        //2.在指定路径文件中读取字符串
        string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
        print(str);

        //使用JsonUtility进行序列化
        //序列化：把内存中的数据 存储到硬盘上
        //方法：JsonUtility.ToJson（对象）
        MrTang t = new MrTang();
        t.name = "tang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;

        t.ids = new int[] { 1, 2, 3, 4 };
        t.ids2 = new List<int> { 1, 2, 3 };
        //JsonUtility不支持字典
        t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = null;//实际上不是空 而是默认值
        //t.s1 = new Student(1, "xiaohong");
        t.s2s = new List<Student>() { new Student(2, "xiaohuang"), new Student(3, "xiaoqiang") };

        string jsonStr = JsonUtility.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrTang.json", jsonStr);


        //反序列化
        //JsonUtility.FromJson(字符串);
        //读取文件中的 Json字符串
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTang.json");
        //使用Json字符串内容 转换成类对象
        MrTang t2 = JsonUtility.FromJson(jsonStr, typeof(MrTang)) as MrTang;
        MrTang t3 = JsonUtility.FromJson<MrTang>(jsonStr);//这个常用

        //JsonUtility无法直接读取数据集合
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
        print(jsonStr);
        //List<RoleInfo> list = JsonUtility.FromJson<List<RoleInfo>>(jsonStr);//报错
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo2.json");
        RoleData data = JsonUtility.FromJson<RoleData>(jsonStr);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
