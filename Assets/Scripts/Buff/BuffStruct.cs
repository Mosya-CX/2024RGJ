using UnityEngine;
// ���·�ʽ
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
// Buff��Ϣ
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
            Debug.LogError($"·��Ϊ��{buffDataPath}����BuffData������");
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