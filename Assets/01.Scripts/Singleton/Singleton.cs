namespace DesignPetton.Singleton
{
    //System
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Instrumentation;

    //UnityEngnie
    using UnityEngine;

    public class Singleton<T> : MonoBehaviour where T : Component
    {
        //내부 지역 변수
        private static T instance;

        //다른 곳에서 사용할 수 있는 인스턴스
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>(); //오브젝트 타입을 찾음
                    if (instance == null) //오브젝트 타입을 못찾으면
                    {
                        GameObject obj = new GameObject(); //오브젝트를 새로 생성
                        obj.name = typeof(T).Name; //오브젝트의 이름을 클래스 이름으로 지정
                        instance = obj.AddComponent<T>(); //오브젝트의 클래스를 추가
                    }
                }

                return instance; //클래스를 반환
            }
        }

        //상속 받아서 재정의 할 수 있다
        public virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T; //클래스를 반환
                DontDestroyOnLoad(gameObject); //프로그램이 종료하기 전까지 계속 살아 있게 함
            }
            else
            {
                Destroy(gameObject); //이미 인스턴스가 있으면 자신 오브젝트를 삭제함
            }
        }
    }

}