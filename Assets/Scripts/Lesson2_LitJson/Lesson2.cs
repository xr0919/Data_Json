using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Student2
{
    public int age;
    public string name;

    //要手动加无参构造 如果有有参构造的话
    public Student2() { }
    public Student2(int age, string name)
    {
        this.age = age;
        this.name = name;
    }
}
public class MrTang2
{
    public string name;
    public int age;
    public bool sex;
    public float testF;
    public double testD;

    public int[] ids;
    public List<int> ids2;
    public Dictionary<string, string> dic;
    public Dictionary<string, string> dic2;

    public Student2 s1;
    public List<Student2> s2s;

    private int privateI = 1;
    protected int protectedI = 2;
}
public class RoleInfo2
{
    public int hp;
    public int speed;
    public int volume;
    public string resName;
    public int scale;
}
public class Lesson2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ///LitJson
        ///i第三方库 用于处理Json的序列化和反序列化
        ///官网litjson.net
        //把下载完的zip里面src里面的LitJson拷贝到项目assets

        ///序列化
        //JsonMapper.ToJson(对象);
        MrTang2 t = new MrTang2();
        t.name = "tang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;

        t.ids = new int[] { 1, 2, 3, 4 };
        t.ids2 = new List<int> { 1, 2, 3 };
        t.dic = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = null;
        //t.s1 = new Student2(1, "xiaohong");
        t.s2s = new List<Student2>() { new Student2(2, "xiaohuang"), new Student2(3, "xiaoqiang") };

        string jsonStr = JsonMapper.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrTang2.json", jsonStr);
        //不需要加特性
        //不能序列号私有变量
        //支持字典 但字典的键建议都是字符串
        //需要引入LitJson命名空间
        //可以准确保存null


        ///反序列化
        //JsonMapper.ToObject(字符串)
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTang2.json");

        JsonData data = JsonMapper.ToObject(jsonStr);//JsonData是LitJson提供的类对象 可以用键值对的形式去访问其中的内容
        print(data["name"]);//少用
        //用泛型的
        MrTang2 t2 = JsonMapper.ToObject<MrTang2>(jsonStr);


        ///注意
        //1.类结构需要无参构造函数（如果有有参构造顶掉无参的情况下） 否则反序列化时报错
        //2.字典虽然支持 但是键在使用为数值时会有问题 需要使用字符串类型

        ///
        //1.LitJson可以直接读取数据集合
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
        RoleInfo2[] arr = JsonMapper.ToObject<RoleInfo2[]>(jsonStr);
        print(arr[0].resName);
        List<RoleInfo2> list = JsonMapper.ToObject<List<RoleInfo2>>(jsonStr);


        //练习题
        JsonMgr.Instance.SaveData(t, "Exercise");
        MrTang2 t2Exe = JsonMgr.Instance.LoadData<MrTang2>("Exercise");
        print(t2Exe.age);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
