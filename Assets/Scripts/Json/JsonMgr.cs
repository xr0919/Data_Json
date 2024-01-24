using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ʹ����һ�ַ��� ö��
/// </summary>
public enum JsonType
{
    JsonUtility,
    LitJson,
}

/// <summary>
/// Json���ݹ����� ��Ҫ���� Json�����л��洢��Ӳ�� �� �����л���Ӳ���ж�ȡ���ڴ���
/// </summary>
public class JsonMgr
{
    private static JsonMgr instance = new JsonMgr();
    private JsonMgr() { }
    public static JsonMgr Instance
    {
        get { return instance; }
    }

    //�洢
    public void SaveData(object data, string path, JsonType type = JsonType.LitJson)//Ĭ��ֵΪLitJson
    {
        string jsonStr = null;
        switch (type)
        {
            case JsonType.JsonUtility:
                jsonStr = JsonUtility.ToJson(data);
                break;
            case JsonType.LitJson:
                jsonStr = JsonMapper.ToJson(data);
                break;
        }
        File.WriteAllText(Application.persistentDataPath + "/" + path + ".json", jsonStr);
    }
    //��ȡ
    public T LoadData<T>(string fileName, JsonType type = JsonType.LitJson) where T:new()//�����T�����޲ι��캯����
    {
        //ȷ������һ��·����ȡ
        //��ϷĬ��������StreamingAssets�����Ǹ�ֻ���ļ���
        //���ж�Ĭ�������ļ����Ƿ���������Ҫ������
        string path =Application.streamingAssetsPath + "/" + fileName + ".json";
        if (!File.Exists(path))
        {
            //��������ھʹӶ�д�ļ���ȥ��
            path = Application.persistentDataPath + "/" + fileName + ".json";
        }
        //�����û�� ����һ��Ĭ�϶���
        if (!File.Exists(path))
        {
            return new T();
        }
        string jsonStr = File.ReadAllText(path);
        //����Ĭ��ֵ
        T t = default(T);
        switch (type)
        {
            case JsonType.JsonUtility:
                t = JsonUtility.FromJson<T>(jsonStr);
                break;
            case JsonType.LitJson:
                t = JsonMapper.ToObject<T>(jsonStr);
                break;
        }
        return t;
    }

}
