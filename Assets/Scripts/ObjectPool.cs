using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    private void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledObjects.Count;i++)
        {
            if (!pooledObjects[i].activeInHierarchy) 
                return pooledObjects[i];
        }
        return null;
    }
}