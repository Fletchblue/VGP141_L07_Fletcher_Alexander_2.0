using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolDictionary : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> poolDict;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject enemy;
        public int size;
    }
    public static PoolDictionary instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Pool> pools;
    
    // Start is called before the first frame update
    void Start()
    {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject temp = Instantiate(pool.enemy);
                temp.SetActive(false);

                objectPool.Enqueue(temp);
            }

            poolDict.Add(pool.tag, objectPool);
        }
    }


    public GameObject spawnEnemy(string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDict.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + "doesn't exist");
            return null;
        }
        GameObject objectSpawning = poolDict[tag].Dequeue();

        objectSpawning.SetActive(true);
        objectSpawning.transform.position = position;
        objectSpawning.transform.rotation = rotation;
        poolDict[tag].Enqueue(objectSpawning);
        return objectSpawning;
    }
}
