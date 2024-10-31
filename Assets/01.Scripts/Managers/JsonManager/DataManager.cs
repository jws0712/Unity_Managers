//System
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Text;

//Unity
using Unity.VisualScripting;

//UnityEngine
using UnityEngine;

//Json
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header("DataManagerInfo")]
    [SerializeField] private string filename        = default;

    public Data gameData = new Data();
    //������ ����
    private Data resetGameData = new Data();
    //�ʱ�ȭ ������ ����

    private string path = default;

    private void Awake()
    {
        #region �̱���
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

        path = Application.persistentDataPath + "/";
    }

    //������ ����
    public void Save()
    {
        string data = JsonConvert.SerializeObject(gameData);
        File.WriteAllText(path + filename, data);
    }

    //������ �ҷ�����
    public void Load()
    {
        //�ش� ��ο� ������ ������ ==> ���� ����
        if(File.Exists(path + filename))
        {
            string data = File.ReadAllText(path + filename);
            gameData = JsonConvert.DeserializeObject<Data>(data);
        }
        else
        {
            //�����ϱ�
            Save();
        }
    }

    //������־��� ������ ����
    public void ResetData()
    {
        gameData = resetGameData;
        Save();
    }
}

public class Data
{
    //������ ������
    //Vector3, MonoBehaviour class ���� �Ұ�
}
