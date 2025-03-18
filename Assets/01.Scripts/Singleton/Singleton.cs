namespace Manager.Game
{
    //System
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Instrumentation;

    //UnityEngnie
    using UnityEngine;

    public class Singleton<T> : MonoBehaviour where T : Component
    {
        //���� ���� ����
        private static T instance;

        //�ٸ� ������ ����� �� �ִ� �ν��Ͻ�
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>(); //������Ʈ Ÿ���� ã��
                    if (instance == null) //������Ʈ Ÿ���� ��ã����
                    {
                        GameObject obj = new GameObject(); //������Ʈ�� ���� ����
                        obj.name = typeof(T).Name; //������Ʈ�� �̸��� Ŭ���� �̸����� ����
                        instance = obj.AddComponent<T>(); //������Ʈ�� Ŭ������ �߰�
                    }
                }

                return instance; //Ŭ������ ��ȯ
            }
        }

        //��� �޾Ƽ� ������ �� �� �ִ�
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T; //Ŭ������ ��ȯ
                DontDestroyOnLoad(gameObject); //���α׷��� �����ϱ� ������ ��� ��� �ְ� ��
            }
            else
            {
                Destroy(gameObject); //�̹� �ν��Ͻ��� ������ �ڽ� ������Ʈ�� ������
            }
        }
    }

}