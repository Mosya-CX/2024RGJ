using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonWithMono<EnemyManager>
{
    public List<GameObject> enemiesToSpawn; // 要生成的敌人
    public List<float> timeToSpawn; // 每种敌人的生成时间
    private List<float> spawnCds; // 每种敌人的生成间隔
    public List<Transform> spawnPositions; // 地图上的生成位置

    private void Start()
    {
        // 初始化生成间隔
        spawnCds = new List<float>(new float[enemiesToSpawn.Count]);
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            spawnCds[i] = timeToSpawn[i];
        }
    }

    void Update()
    {
        for (int i = 0; i < enemiesToSpawn.Count; i++)
        {
            if (spawnCds[i] > 0)
            {
                spawnCds[i] -= Time.deltaTime;
            }
            else
            {
                SpawnEnemy(enemiesToSpawn[i], spawnPositions[i % spawnPositions.Count].position, spawnPositions[i % spawnPositions.Count].rotation);
                spawnCds[i] = timeToSpawn[i]; // 重置生成间隔
            }
        }
    }

    private void SpawnEnemy(GameObject enemy, Vector3 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
    }
}
