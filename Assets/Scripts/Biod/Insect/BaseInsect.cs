using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInsect : BaseBiod
{


    public override BiodType biodType { get => BiodType.Insect; }

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
