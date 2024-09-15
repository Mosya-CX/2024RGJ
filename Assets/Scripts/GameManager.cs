using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonWithMono<GameManager>
{
    public Dictionary<string, BiodManager> biods;
    protected override void Awake()
    {
        base.Awake();
        UIManager.Instance.Init();
        AudioManager.Instance.Init();
        biods = new Dictionary<string, BiodManager>();
    }
}
