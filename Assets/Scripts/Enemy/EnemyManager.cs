using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : SingletonWithMono<EnemyManager>
{
    public GameObject enemy1ToSpawn;
    public GameObject enemy2ToSpawn;
    public GameObject enemy3ToSpawn;

    public float spawnTime = 2.0f; // ����ʱ��
    private float spawnCd; // ��ǰ���ɼ��

    public float enemy1Probability = 0.5f; // ����1�ĸ���
    public float enemy2Probability = 0.3f; // ����2�ĸ���
    public float enemy3Probability = 0.2f; // ����3�ĸ���

    public Transform[] spawnPositions; // ָ��������λ��
    public float spawnRadius = 5.0f; // ����λ�õĸ�����Χ

    private void Start()
    {
        spawnCd = spawnTime;
    }

    void Update()
    {
        spawnCd -= Time.deltaTime;
        if (spawnCd <= 0)
        {
            spawnCd = spawnTime;
            SpawnBatch();
        }
    }

    private void SpawnBatch()
    {
        for (int i = 0; i < 10; i++) // һ������10������
        {
            GameObject enemyToSpawn = ChooseEnemyByProbability();
            SpawnEnemy(enemyToSpawn);
        }
    }

    private GameObject ChooseEnemyByProbability()
    {
        float randomValue = Random.value;
        if (randomValue < enemy1Probability)
        {
            return enemy1ToSpawn;
        }
        else if (randomValue < enemy1Probability + enemy2Probability)
        {
            return enemy2ToSpawn;
        }
        else
        {
            return enemy3ToSpawn;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        if (spawnPositions.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPositions.Length);
            Vector3 position = spawnPositions[randomIndex].position;
            position += Random.insideUnitSphere * spawnRadius;
            Quaternion rotation = Quaternion.identity;
            Instantiate(enemy, position, rotation);
        }
    }
}
