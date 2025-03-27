using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[Serializable]
public class PoolObjectData
{
    public GameObject poolPrefabObj = null;
    public int poolCount = default;
    [HideInInspector] public Queue<GameObject> poolObjectContainer = new Queue<GameObject>();
}
