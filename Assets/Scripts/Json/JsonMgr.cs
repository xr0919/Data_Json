using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 使用哪一种方案 枚举
/// </summary>
public enum JsonType
{
    JsonUtility,
    LitJson,
}

/// <summary>
/// Json数据管理类 主要用于 Json的序列化存储到硬盘 和 反序列化从硬盘中读取到内存中
/// </summary>
public class JsonMgr
{
    private static JsonMgr instance = new JsonMgr();
    private JsonMgr() { }
    public static JsonMgr Instance
    {
        get { return instance; }
    }

    //存储
    public void SaveData(object data, string path, JsonType type = JsonType.LitJson)//默认值为LitJson
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
    //读取
    public T LoadData<T>(string fileName, JsonType type = JsonType.LitJson) where T:new()//让这个T是有无参构造函数的
    {
        //确定是哪一个路径读取
        //游戏默认数据在StreamingAssets，这是个只读文件夹
        //先判断默认数据文件夹是否有我们想要的数据
        string path =Application.streamingAssetsPath + "/" + fileName + ".json";
        if (!File.Exists(path))
        {
            //如果不存在就从读写文件夹去找
            path = Application.persistentDataPath + "/" + fileName + ".json";
        }
        //如果都没有 返回一个默认对象
        if (!File.Exists(path))
        {
            return new T();
        }
        string jsonStr = File.ReadAllText(path);
        //数据默认值
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
