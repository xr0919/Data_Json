using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Student2
{
    public int age;
    public string name;

    //Ҫ�ֶ����޲ι��� ������вι���Ļ�
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
        ///i�������� ���ڴ���Json�����л��ͷ����л�
        ///����litjson.net
        //���������zip����src�����LitJson��������Ŀassets

        ///���л�
        //JsonMapper.ToJson(����);
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
        //����Ҫ������
        //�������к�˽�б���
        //֧���ֵ� ���ֵ�ļ����鶼���ַ���
        //��Ҫ����LitJson�����ռ�
        //����׼ȷ����null


        ///�����л�
        //JsonMapper.ToObject(�ַ���)
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTang2.json");

        JsonData data = JsonMapper.ToObject(jsonStr);//JsonData��LitJson�ṩ������� �����ü�ֵ�Ե���ʽȥ�������е�����
        print(data["name"]);//����
        //�÷��͵�
        MrTang2 t2 = JsonMapper.ToObject<MrTang2>(jsonStr);


        ///ע��
        //1.��ṹ��Ҫ�޲ι��캯����������вι��춥���޲ε�����£� �������л�ʱ����
        //2.�ֵ���Ȼ֧�� ���Ǽ���ʹ��Ϊ��ֵʱ�������� ��Ҫʹ���ַ�������

        ///
        //1.LitJson����ֱ�Ӷ�ȡ���ݼ���
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
        RoleInfo2[] arr = JsonMapper.ToObject<RoleInfo2[]>(jsonStr);
        print(arr[0].resName);
        List<RoleInfo2> list = JsonMapper.ToObject<List<RoleInfo2>>(jsonStr);


        //��ϰ��
        JsonMgr.Instance.SaveData(t, "Exercise");
        MrTang2 t2Exe = JsonMgr.Instance.LoadData<MrTang2>("Exercise");
        print(t2Exe.age);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
