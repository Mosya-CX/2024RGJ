using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BiodManager : MonoBehaviour
{
    public string uid;
    List<BaseBiod> biods;
    public float spawnVelocity;//����ʼ�ٶ�
    public float minVelocity;//��С�ٶ�
    public float maxVelocity;//����ٶ�
    public float nearDist;
    public float collisionDist;
    public float velocityMatchingAmt;
    public float flockCenteringAmt;
    public float collisionAvoidanceAmt;
    public float targetAtrractionAmt;
    public float targetAvoidanceAmt;
    public float targetAvoidanceDist;
    public float velocityLerpAmt;// �ٶȲ�ֵ����

    public BiodManager(BaseBiod firstBiod)
    {
        biods = new List<BaseBiod>();
        biods.Add(firstBiod);
        //uid = 
    }

    public void AddBiod(BaseBiod newBiod)
    {
        biods.Add(newBiod);
    }

    public void RemoveBiod(BaseBiod oldBiod)
    {
        biods.Remove(oldBiod);
    }

    public void Update()
    {
        ThreadPool.QueueUserWorkItem((callback)=>
        {
            foreach (var biod in biods)
            {

            }
        }, null);
    }
}
