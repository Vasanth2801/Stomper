using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public string objectTag;
        public GameObject prefab;
        public int size;
    }

    public ObjectPoolItem[] pools;
    public Dictionary<string, Queue<GameObject>> poolsOfDictionary;

    void Start()
    {
        poolsOfDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(ObjectPoolItem pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();
            for(int i=0; i<pool.size;i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }
            poolsOfDictionary.Add(pool.objectTag, objPool);
        }
    }

    public GameObject SpawnFromPools(string tag, Vector3 position, Quaternion rotation)
    {
        
        GameObject objectToSpawn = poolsOfDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        poolsOfDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}