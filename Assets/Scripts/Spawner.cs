using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    bool hasRunOnce = false;
    void FixedUpdate()
    {
        if (!hasRunOnce)
        {
            PoolDictionary.instance.spawnEnemy("Enemy", transform.position, Quaternion.identity);
            hasRunOnce = true;
        }

    }
}
