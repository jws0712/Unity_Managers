using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool; //유니티 오브젝트 풀링 사용 using

public class Bullet : MonoBehaviour
{
    private Vector3 _Direction;

    [SerializeField]
    private float _Speed = 3f;

    //풀사용 코드
    private IObjectPool<Bullet> _ManagedPool;

    public void Shoot(Vector3 dir)
    {
        _Direction = dir;
        // 5초가 지난 후 총알을 파괴
        Invoke("DestroyObject", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_Direction * Time.deltaTime * _Speed);
    }

    //오브젝트를 릴리즈 해줌 Destory함수 대용
    public void DestroyObject()
    {
        ObjectPoolManager.Instance.ReturnObject(gameObject);
    }
}
