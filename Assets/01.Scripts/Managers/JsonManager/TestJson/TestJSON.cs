using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. 데이터(코드 = 클래스)를 만들어야함 => 저장할 데이터 생성
//2. 그 데이터를 Json으로 변환. (택배상자로 포장)
//=========================================================
//1. Json(택배)를 다시 원래의 코드로 바꾸는 방법
//제이슨(택배) -> 조립도 -> 클래스(코드)

class Data
{
    public string nickName;
    public int level;
    public int coin = 100; //초깃값 설정가능
    public bool skill;
    //기타 등등...
}

public class TestJSON : MonoBehaviour
{
    Data player = new Data() { nickName = "전우성", level = 50, coin = 200, skill = false};

    void Start()
    {
        //player.nickName = "전우성";

        //2. Json으로 변환
        string jasonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jasonData);
    }
}
