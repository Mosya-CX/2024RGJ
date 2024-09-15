using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonWithMono<EnemyManager>
{
    public GameObject enemyToSpawn;

    public float timeToSpawn;
    private float spawnCd;

    private void Start()
    {
        spawnCd = timeToSpawn;
    }

    void Update()
    {
        spawnCd -= Time.deltaTime;
        if(spawnCd <= 0) 
        {
            spawnCd = timeToSpawn;

            Instantiate(enemyToSpawn,transform.position,transform.rotation);
        }
    }
}
