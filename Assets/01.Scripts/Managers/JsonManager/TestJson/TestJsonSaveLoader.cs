using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Text;
using UnityEditor.Rendering;

public class TestJsonSaveLoader : MonoBehaviour
{
    private void Start()
    {
        //�ø�������� Save
        //FileStream stream = new FileStream(Application.dataPath + "/test.json", FileMode.OpenOrCreate);
        //JsonTestClass jTest1 = new JsonTestClass();
        //string jsonData = JsonConvert.SerializeObject(jTest1);
        //byte[] data = Encoding.UTF8.GetBytes(jsonData);
        //stream.Write(data, 0, data.Length);
        //stream.Close();

        //��ø�������� Load
        FileStream stream = new FileStream(Application.dataPath + "/test.json", FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        JsonTestClass jTest2 = JsonConvert.DeserializeObject<JsonTestClass>(jsonData);
        jTest2.Print();
    }
}
