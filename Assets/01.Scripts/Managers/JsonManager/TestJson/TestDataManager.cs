using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//저장하는 방법
//1. 저장할 데이터가 존재
//2. 데이터를 제이슨으로 변환
//3. 제이슨을 외부에 저장

//불러오는 방법
//1. 외부에 저장된 제이슨을 가져옴
//2. 제이슨을 데이터형태로 변환
//3. 불러온 데이터를 사용

public class PlayerData
{
    public string name;
    public int level;
    public int coin;
    public int item;
}

public class TestDataManager : MonoBehaviour
{
    public static TestDataManager instance;

    PlayerData nowPlayer = new PlayerData();

    string path;
    string filename = "save";

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/"; //유니티 자체 기본 경로
                                                     //추가 경로를 위한 "/"
    }

    void Start()
    {
        SaveData();
    }
    
    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);

        File.WriteAllText(path + filename, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }
}
