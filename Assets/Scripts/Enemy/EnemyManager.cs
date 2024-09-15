using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonWithMono<EnemyManager>
{
    public GameObject[] enemiesToSpawn; // 要生成的敌人
    public float[] timeToSpawn; // 每种敌人的生成时间
    private float[] spawnCds; // 每种敌人的生成间隔
    public Transform[] spawnPositions; // 地图上的生成位置

    private void Start()
    {
        // 初始化生成间隔数组
        spawnCds = new float[enemiesToSpawn.Length];
        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            spawnCds[i] = timeToSpawn[i];
        }
    }

    void Update()
    {
        for (int i = 0; i < enemiesToSpawn.Length; i++)
        {
            spawnCds[i] -= Time.deltaTime;
            if (spawnCds[i] <= 0)
            {
                spawnCds[i] = timeToSpawn[i];
                SpawnEnemy(enemiesToSpawn[i], spawnPositions[i].position, spawnPositions[i].rotation);
            }
        }
    }

    private void SpawnEnemy(GameObject enemy, Vector2 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
    }
}
