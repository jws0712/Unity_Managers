using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�����ϴ� ���
//1. ������ �����Ͱ� ����
//2. �����͸� ���̽����� ��ȯ
//3. ���̽��� �ܺο� ����

//�ҷ����� ���
//1. �ܺο� ����� ���̽��� ������
//2. ���̽��� ���������·� ��ȯ
//3. �ҷ��� �����͸� ���

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

        path = Application.persistentDataPath + "/"; //����Ƽ ��ü �⺻ ���
                                                     //�߰� ��θ� ���� "/"
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
