using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBeast : BaseBiod
{
    private void Awake()
    {
        info = baseInfo;
    }

    public override BiodInfo baseInfo => new BiodInfo(200, 5, 100, 100);

    public override BiodType biodType { get => BiodType.Beast; }

}
