using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BiodManager : MonoBehaviour
{
    public string uid;
    List<BaseBiod> biods;

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
