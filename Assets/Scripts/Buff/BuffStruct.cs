using UnityEngine;
// 更新方式
public enum BuffUpdateTimeEnum
{
    Add,
    Replace,
    Keep,
}
public enum BuffRemoveUpdateEnum
{
    Clear,
    Consume,
}
// Buff信息
[System.Serializable]
public class BuffInfo
{
    public BuffInfo(string buffDataPath, GameObject source, GameObject target)
    {
        buffData = Resources.Load<BuffData>(buffDataPath);
        this.source = source;
        this.target = target;
        if (buffData == null)
        {
            Debug.LogError($"路径为【{buffDataPath}】的BuffData不存在");
        }
    }
    public BuffData buffData;
    public GameObject source;
    public GameObject target;
    public float durationTimer;
    public float tickTimer;
    public int curStack;
}
public class DamageInfo
{
    public GameObject source;
    public GameObject target;
    public float damage;
}