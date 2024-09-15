using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBeast : BaseBiod
{
    private void Awake()
    {
        info = baseInfo;
    }

    public override BiodInfo baseInfo => new BiodInfo(200, 5, 100, 100, 50);

    public override BiodType biodType { get => BiodType.Beast; }


    public override void Eat()
    {
        throw new System.NotImplementedException();
    }

    public override void Fight(BaseBiod target)
    {
        throw new System.NotImplementedException();
    }

    public override void Foraging()
    {
        throw new System.NotImplementedException();
    }

    public override void Mathing()
    {
        throw new System.NotImplementedException();
    }

    public override void Move()
    {
        throw new System.NotImplementedException();
    }

    public override void Run()
    {
        throw new System.NotImplementedException();
    }
}
