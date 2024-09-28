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

        //모노베히비어 상속받은 클래스 스리얼라이즈
        //GameObject obj = new GameObject();
        //var test1 = obj.AddComponent<TestMono>();
        //test1.i = 100;
        //test1.v3 /= 10;
        //string jsonData = JsonUtility.ToJson(obj.GetComponent<TestMono>()); //GetComponent로 직접 가져온 클래스의 오브젝트로 시리얼라이즈
        //Debug.Log(jsonData);

        //JsonUtility.FromJson<TestMono>(jsonData);


        //모노베히비어 상속받은 클래스 디시리얼라이즈시 사용
        //GameObject obj2 = new GameObject();
        //JsonUtility.FromJsonOverwrite(jsonData, obj2.AddComponent<TestMono>());
    }
}
