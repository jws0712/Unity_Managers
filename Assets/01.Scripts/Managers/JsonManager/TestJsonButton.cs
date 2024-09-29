//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class TestJsonButton : MonoBehaviour
//{
//    [Header("TestInfo")]
//    [SerializeField] private Button plusButton = null;
//    [SerializeField] private Button saveButton = null;
//    [SerializeField] private Text testText     = null;

//    private void Start()
//    {
//        DataManager.instance.Load();
//        testText.text = DataManager.instance.gameData.test.ToString();
//    }

//    public void PlusButton()
//    {
//        DataManager.instance.gameData.test++;
//        testText.text = DataManager.instance.gameData.test.ToString();
//    }
//    public void SaveButton()
//    {
//        DataManager.instance.Save();
//    }

//    public void Reset()
//    {
//        DataManager.instance.ResetData();
//        testText.text = DataManager.instance.gameData.test.ToString();
//    }
//}
