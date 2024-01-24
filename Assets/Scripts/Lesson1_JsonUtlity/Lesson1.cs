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
//��������಻�ü�[System.Serializable] ������������˱���Զ������Ҫ
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

    //��Ҫ���л�˽�б���
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
        //JsonUtlity Unity�Դ����ڽ���Json�Ĺ�����

        //���ļ��д���ַ���
        //1.�洢�ַ������Զ�·���ļ���
        //-1��һ������ �洢��·�� һ��Ҫ��֤�ļ����Ǵ��ڵ� "/Json/Test.json"����û��Json�ļ��лᱨ��
        //-2�ڶ������� �洢���ַ�������
        File.WriteAllText(Application.persistentDataPath + "/Test.json", "�洢��json�ļ�");
        print(Application.persistentDataPath);
        //2.��ָ��·���ļ��ж�ȡ�ַ���
        string str = File.ReadAllText(Application.persistentDataPath + "/Test.json");
        print(str);

        //ʹ��JsonUtility�������л�
        //���л������ڴ��е����� �洢��Ӳ����
        //������JsonUtility.ToJson������
        MrTang t = new MrTang();
        t.name = "tang";
        t.age = 18;
        t.sex = false;
        t.testF = 1.4f;
        t.testD = 1.4;

        t.ids = new int[] { 1, 2, 3, 4 };
        t.ids2 = new List<int> { 1, 2, 3 };
        //JsonUtility��֧���ֵ�
        t.dic = new Dictionary<int, string>() { { 1, "123" }, { 2, "234" } };
        t.dic2 = new Dictionary<string, string>() { { "1", "123" }, { "2", "234" } };

        t.s1 = null;//ʵ���ϲ��ǿ� ����Ĭ��ֵ
        //t.s1 = new Student(1, "xiaohong");
        t.s2s = new List<Student>() { new Student(2, "xiaohuang"), new Student(3, "xiaoqiang") };

        string jsonStr = JsonUtility.ToJson(t);
        File.WriteAllText(Application.persistentDataPath + "/MrTang.json", jsonStr);


        //�����л�
        //JsonUtility.FromJson(�ַ���);
        //��ȡ�ļ��е� Json�ַ���
        jsonStr = File.ReadAllText(Application.persistentDataPath + "/MrTang.json");
        //ʹ��Json�ַ������� ת���������
        MrTang t2 = JsonUtility.FromJson(jsonStr, typeof(MrTang)) as MrTang;
        MrTang t3 = JsonUtility.FromJson<MrTang>(jsonStr);//�������

        //JsonUtility�޷�ֱ�Ӷ�ȡ���ݼ���
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo.json");
        print(jsonStr);
        //List<RoleInfo> list = JsonUtility.FromJson<List<RoleInfo>>(jsonStr);//����
        jsonStr = File.ReadAllText(Application.streamingAssetsPath + "/RoleInfo2.json");
        RoleData data = JsonUtility.FromJson<RoleData>(jsonStr);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
