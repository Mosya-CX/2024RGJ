using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BiodManager : MonoBehaviour
{
    public string uid;
    List<BaseBiod> biods;
    public float spawnVelocity;//最大初始速度
    public float minVelocity;//最小速度
    public float maxVelocity;//最大速度
    public float nearDist;
    public float collisionDist;
    public float velocityMatchingAmt;
    public float flockCenteringAmt;
    public float collisionAvoidanceAmt;
    public float targetAtrractionAmt;
    public float targetAvoidanceAmt;
    public float targetAvoidanceDist;
    public float velocityLerpAmt;// 速度插值乘数

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
