using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. ������(�ڵ� = Ŭ����)�� �������� => ������ ������ ����
//2. �� �����͸� Json���� ��ȯ. (�ù���ڷ� ����)
//=========================================================
//1. Json(�ù�)�� �ٽ� ������ �ڵ�� �ٲٴ� ���
//���̽�(�ù�) -> ������ -> Ŭ����(�ڵ�)

class Data
{
    public string nickName;
    public int level;
    public int coin = 100; //�ʱ갪 ��������
    public bool skill;
    //��Ÿ ���...
}

public class TestJSON : MonoBehaviour
{
    Data player = new Data() { nickName = "���켺", level = 50, coin = 200, skill = false};

    void Start()
    {
        //player.nickName = "���켺";

        //2. Json���� ��ȯ
        string jasonData = JsonUtility.ToJson(player);

        Data player2 = JsonUtility.FromJson<Data>(jasonData);
    }
}
