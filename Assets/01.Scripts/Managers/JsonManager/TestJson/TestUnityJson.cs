using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnityJson : MonoBehaviour
{
    private void Start()
    {
        //JsonTestClass jTest1 = new JsonTestClass();
        //string jsonData = JsonUtility.ToJson(jTest1);
        //Debug.Log(jsonData);

        //JsonTestClass jTest2 = JsonUtility.FromJson<JsonTestClass>(jsonData);
        //jTest2.Print();

        //��뺣����� ��ӹ��� Ŭ���� �����������
        //GameObject obj = new GameObject();
        //var test1 = obj.AddComponent<TestMono>();
        //test1.i = 100;
        //test1.v3 /= 10;
        //string jsonData = JsonUtility.ToJson(obj.GetComponent<TestMono>()); //GetComponent�� ���� ������ Ŭ������ ������Ʈ�� �ø��������
        //Debug.Log(jsonData);

        //JsonUtility.FromJson<TestMono>(jsonData);


        //��뺣����� ��ӹ��� Ŭ���� ��ø��������� ���
        //GameObject obj2 = new GameObject();
        //JsonUtility.FromJsonOverwrite(jsonData, obj2.AddComponent<TestMono>());
    }
}
