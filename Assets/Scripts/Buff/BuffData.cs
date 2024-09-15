using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Buffϵͳ/NewBuff", fileName = "NewBuff")]
public class BuffData : ScriptableObject
{
    [Header("������Ϣ")]
    public int Id;
    public string Name;
    public string Description;
    public Sprite Icon;
    public int Priority;
    public bool isStackable;
    public int MaxStack;
    public string[] Tags;
    [Header("ʱ����Ϣ")]
    public bool isForever;
    public float Duration;
    public float TickTime;
    [Header("���·�ʽ")]
    public BuffUpdateTimeEnum UpdateTimeMode;
    public BuffRemoveUpdateEnum RemoveUpdateMode;
    [Header("�����ص���")]
    public BaseBuffModule OnCreate;
    public BaseBuffModule OnRemove;
    public BaseBuffModule OnTick;
    [Header("�˺��ص���")]
    public BaseBuffModule OnHit;// �� ���� ʱ
    public BaseBuffModule OnHurt;// �� ����/�ܻ� ʱ
    public BaseBuffModule OnKill;// �� ��ɱ ʱ
    public BaseBuffModule OnDeath;// �� ����/����ɱ ʱ
}
