using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class ObjectPool
{
    public string Name;
    public GameObject prefab;
    public int Size;
}

public class ObjectPoolManager : MonoBehaviour
{
    public List<ObjectPool> ObjectPoolList;
    public static ObjectPoolManager instance;

    private static Dictionary<string, Queue<GameObject>> objectPoolDictionary;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    private void Start()
    {
        
        objectPoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (ObjectPool pool in ObjectPoolList)
        {
            GameObject poolParentObj = new GameObject();
            poolParentObj.name = pool.Name + "Pool";
            GameObject.DontDestroyOnLoad(poolParentObj);

            // create object pool and store objects to it
            Queue<GameObject> poolQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = GameObject.Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = poolParentObj.transform;
                //ActionManager SpawnedObjectBehaviour = obj.AddComponent<ActionManager>();
                //SpawnedObjectBehaviour.pool = pool;
                poolQueue.Enqueue(obj);
            }
            objectPoolDictionary.Add(pool.Name, poolQueue);
        }
    }
    public static GameObject GetObjectFromPool(string poolName)
    {
        if (objectPoolDictionary.ContainsKey(poolName))
        {
            if (objectPoolDictionary[poolName].Count > 0)
            {
                GameObject obj = objectPoolDictionary[poolName].Dequeue();
                obj.SetActive(true);
                objectPoolDictionary[poolName].Enqueue(obj);
                return obj;
            }
            else
            {
                Debug.Log(poolName + " is empty");
                return null;
            }
        }
        else
        {
            Debug.Log(poolName + " object pool is not available");
            return null;
        }
    }

    public static void ReturnObjectToPool(GameObject poolObject)
    {
        if (objectPoolDictionary.ContainsKey(poolObject.name))
        {
            objectPoolDictionary[poolObject.name].Enqueue(poolObject);
            poolObject.SetActive(false);
        }
        else
        {
            Queue<GameObject> CloneObject = new Queue<GameObject>();
            CloneObject.Enqueue(poolObject);
            poolObject.SetActive(false);
            objectPoolDictionary.Add(poolObject.name, CloneObject);
            Debug.Log(poolObject.name + " object pool is not available");
        }
    }
}