using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonWithMono<EnemyManager>
{
    public List<GameObject> enemiesToSpawn; // Ҫ���ɵĵ���
    public List<float> timeToSpawn; // ÿ�ֵ��˵�����ʱ��
    private List<float> spawnCds; // ÿ�ֵ��˵����ɼ��
    public List<Transform> spawnPositions; // ��ͼ�ϵ�����λ��

    private void Start()
    {
        // ��ʼ�����ɼ��
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
                spawnCds[i] = timeToSpawn[i]; // �������ɼ��
            }
        }
    }

    private void SpawnEnemy(GameObject enemy, Vector3 position, Quaternion rotation)
    {
        Instantiate(enemy, position, rotation);
    }
}
