using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonWithMono<EnemyManager>
{
    public GameObject[] enemiesToSpawn; // Ҫ���ɵĵ���
    public float[] timeToSpawn; // ÿ�ֵ��˵�����ʱ��
    private float[] spawnCds; // ÿ�ֵ��˵����ɼ��
    public Transform[] spawnPositions; // ��ͼ�ϵ�����λ��

    private void Start()
    {
        // ��ʼ�����ɼ������
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
