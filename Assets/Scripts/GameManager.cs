using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    protected override void Awake()
    {
        base.Awake();
        UIManager.Instance.Init();
        AudioManager.Instance.Init();
    }
}
