using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : ScriptableObject, IInitializable where T : Component
{
    List<PooledObject> pool = new List<PooledObject>();

    [SerializeField] private T prefab;
    [SerializeField] private int poolStartSize; // How many objects to add to the pool at the start
    [SerializeField] private int poolIncreaseSize; // How many objects to add to the pool when it runs out
    private Transform parent;

    public void Initialize()
    {
        parent = new GameObject(prefab.name + " Pool").transform;
        DontDestroyOnLoad(parent);
        pool = new List<PooledObject>();
        PopulatePool(poolStartSize);
    }

    public void PopulatePool(int increase = 1)
    {
        for (int i = 0; i < increase; i++)
        {
            T obj = Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            PooledObject pooledObj = new PooledObject { MyPool = this, obj = obj };
            pool.Add(pooledObj);
        }
    }

    public PooledObject GetObject()
    {
        if (pool.Count == 0)
        {
            PopulatePool(poolIncreaseSize);
        }

        PooledObject pooledObj = pool[0];
        pool.RemoveAt(0);
        pooledObj.obj.gameObject.SetActive(true);
        return pooledObj;
    }

    [Serializable]
    public class PooledObject
    {
        public ObjectPool<T> MyPool;
        public T obj;
        public void ReturnToPool()
        {
            obj.gameObject.SetActive(false);
            MyPool.pool.Add(this);
        }
    }
}