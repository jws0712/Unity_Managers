using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPetton.Singleton;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    [SerializeField] private PoolObjectData[] poolObjDataArray = null;

    private Dictionary<string, Queue<GameObject>> poolObjDataDict = new Dictionary<string, Queue<GameObject>>();

    public override void Awake()
    {
        base.Awake();

        InitPool();
    }

    private void InitPool()
    {
        foreach (PoolObjectData poolObjData in poolObjDataArray)
        {
            poolObjDataDict.Add(poolObjData.poolPrefabObj.name, GetPoolDataQueue(poolObjData.poolObjectContainer, poolObjData.poolPrefabObj, poolObjData.poolCount));
        }
    }

    private Queue<GameObject> GetPoolDataQueue(Queue<GameObject> poolObjQueue, GameObject poolObj, int poolCount)
    {
        for (int i = 0; i < poolCount; i++)
        {
            poolObjQueue.Enqueue(CreateObjcet(poolObj));
        }

        return poolObjQueue;
    }

    private GameObject CreateObjcet(GameObject poolObj)
    {
        GameObject obj = Instantiate(poolObj);
        obj.name = poolObj.name;
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        return obj;
    }

    public GameObject GetPoolObject(string objName)
    {
        if (poolObjDataDict[objName].Count > 0)
        {
            var obj = poolObjDataDict[objName].Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            PoolObjectData findObj = Array.Find(poolObjDataArray, x => x.poolPrefabObj.name == objName);

            if (findObj != null)
            {
                var obj = CreateObjcet(findObj.poolPrefabObj);
                obj.transform.SetParent(null);
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                Debug.LogError("ERROR : OBJCET NOT FOUND");
                return null;
            }

        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        poolObjDataDict[obj.name].Enqueue(obj);
    }

    public void ClearPool()
    {
        poolObjDataDict.Clear();

        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
