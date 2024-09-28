using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Rendering;

public class TestOtherJSON : MonoBehaviour
{
    private void Start()
    {
        //JsonTestClass jTest1 = new JsonTestClass();
        //string jsonData = JsonConvert.SerializeObject(jTest1);
        //Debug.Log(jsonData);

        //JsonTestClass jTest2 = JsonConvert.DeserializeObject<JsonTestClass>(jsonData);
        //jTest2.Print();

        //Newtonsoft Json : 모노배히비어 시리얼라이즈 불가능, Vector3 시리얼라이즈 불가능
        //이유 : 자기참조루프 오류에 걸림

        //둘다 가능하지만 오류가 많이 남 - 사용을 권장하지 않음
        //Vector3의 경우 별도로 Class를 만들어서 만든 클래스로 시리얼라이즈를 할 수 있음
        //GameObject obj = new GameObject();
        //obj.AddComponent<TestOtherJSON>();
        //Debug.Log(JsonConvert.SerializeObject(obj.GetComponent<TestMono>()));
    }
}

public class JsonTestClass
{
    public int i;
    public float f;
    public bool b;
    public string str;
    public int[] iArray;
    public List<int> iList = new List<int>();
    public Dictionary<string, float> fDictionary = new Dictionary<string, float>();
    public IntVector2 iVector;

    public JsonTestClass()
    {
        i = 10;
        f = 99.9f;
        b = true;
        str = "JSON Test String";
        iArray = new int[] { 1, 1, 2, 3, 5, 8, 12, 21, 34, 55 };

        for (int idx = 0; idx < 5; idx++)
        {
            iList.Add(2 * idx);
        }

        fDictionary.Add("PIE", Mathf.PI);
        fDictionary.Add("Epsilon", Mathf.Epsilon);
        fDictionary.Add("Sqrt(2)", Mathf.Sqrt(2));

        iVector = new IntVector2(3, 2);
    }

    public void Print()
    {
        Debug.Log($"i = {i}");
        Debug.Log($"f = {f}");
        Debug.Log($"b = {b}");
        Debug.Log($"str = {str}");

        for(int idx = 0; idx < iArray.Length; idx++)
        {
            Debug.Log(string.Format("iArray[{0}] = {1}", idx, iArray[idx]));
        }
        for (int idx = 0; idx < iList.Count; idx++)
        {
            Debug.Log(string.Format("iList[{0}] = {1}", idx, iList[idx]));
        }
        foreach(var data in fDictionary)
        {
            Debug.Log(string.Format("iDictionary[{0}] = {1}", data.Key, data.Value));
        }

        Debug.Log($"iVector = {iVector.x}, {iVector.y}");
    }

    public class IntVector2
    {
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
