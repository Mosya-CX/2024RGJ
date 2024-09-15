using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuffHandler : MonoBehaviour 
{
    public LinkedList<BuffInfo> buffList = new LinkedList<BuffInfo>();

    private void Update()
    {
        UpdateBuff();
    }

    public void UpdateBuff()
    {
        List<BuffInfo> deleBuffCache = new List<BuffInfo>();
        foreach (BuffInfo buffInfo in buffList)
        {
            if (buffInfo.buffData.OnTick != null)
            {
                
                if (buffInfo.tickTimer <= 0)
                {
                    buffInfo.buffData.OnTick.Apply(buffInfo);
                    buffInfo.tickTimer = buffInfo.buffData.TickTime;
                }
                else
                {
                    buffInfo.tickTimer -= Time.deltaTime;
                }
            }
            if (!buffInfo.buffData.isForever)
            {
                if (buffInfo.durationTimer <= 0)
                {
                    deleBuffCache.Add(buffInfo);
                }
                else
                {
                    buffInfo.durationTimer -= Time.deltaTime;
                }
            }
        }
        if (deleBuffCache.Count > 0)
        {
            for (int i = 0; i < deleBuffCache.Count; i++)
            {
                RemoveBuff(deleBuffCache[i]);
            }
        }
    }

    public void AddBuff(BuffInfo info)
    {
        BuffInfo buffInfo = FindeBuff(info.buffData.Id);
        // 先判断Buff是否已经存在
        if (buffInfo != null)
        {
            if (buffInfo.buffData.isStackable)
            {
                // 再判断buff的叠加层数是否已经达到最大层
                if (buffInfo.curStack < buffInfo.buffData.MaxStack)
                {
                    buffInfo.curStack++;
                    // 然后判断buff的更新方式
                    switch (buffInfo.buffData.UpdateTimeMode)
                    {
                        case BuffUpdateTimeEnum.Add:
                            buffInfo.durationTimer += buffInfo.buffData.Duration;
                            break;
                        case BuffUpdateTimeEnum.Replace:
                            buffInfo.durationTimer = buffInfo.buffData.Duration;
                            break;
                        case BuffUpdateTimeEnum.Keep:
                            break;
                    }
                    // 最后调用 OnCreate()
                    buffInfo.buffData.OnCreate.Apply(buffInfo);
                }
            }
            else
            {
                switch (buffInfo.buffData.UpdateTimeMode)
                {
                    case BuffUpdateTimeEnum.Add:
                        buffInfo.durationTimer += buffInfo.buffData.Duration;
                        buffInfo.buffData.OnCreate.Apply(buffInfo);
                        break;
                    case BuffUpdateTimeEnum.Replace:
                        buffInfo.durationTimer = buffInfo.buffData.Duration;
                        buffInfo.buffData.OnCreate.Apply(buffInfo);
                        break;
                    case BuffUpdateTimeEnum.Keep:
                        break;
                }
            }
        }
        else
        {
            info.curStack = 1;
            info.durationTimer = info.buffData.Duration;
            info.tickTimer = info.buffData.TickTime;
            info.buffData.OnCreate.Apply(info);
            buffList.AddLast(info);
            SortBuffList(buffList); 
        }
    }
    public void RemoveBuff(BuffInfo info)
    {
        BuffInfo buffInfo = FindeBuff(info.buffData.Id);
        if (buffInfo != null )
        {
            buffInfo.buffData.OnRemove?.Apply(buffInfo);
            if (buffInfo.buffData.isStackable)
            {
                switch (buffInfo.buffData.RemoveUpdateMode)
                {
                    case BuffRemoveUpdateEnum.Clear:
                        buffList.Remove(buffInfo);
                        break;
                    case BuffRemoveUpdateEnum.Consume:
                        buffInfo.curStack--;
                        if (buffInfo.curStack == 0)
                        {
                            buffList.Remove(buffInfo);
                        }
                        else
                        {
                            buffInfo.durationTimer = buffInfo.buffData.Duration;
                        }
                        break;
                }
            }
            else
            {
                buffList.Remove(buffInfo);
            }
        }
        else
        {
            Debug.LogError($"未找到目标buff，无法进行Reduce操作【{info.buffData.Name}】");
        }
    }

    public BuffInfo FindeBuff(int buffId)
    {
        foreach (BuffInfo info in buffList)
        {
            if (info.buffData.Id == buffId)
            {
                return info;
            }
        }
        return null;
    }

    public void SortBuffList(LinkedList<BuffInfo> list)
    {
        if (list == null || list.First == null)
        {
            Debug.LogError("空链表无法排序");
            return;
        }
        LinkedListNode<BuffInfo> current = list.First;
        while (current != null)
        {
            LinkedListNode<BuffInfo> next = current.Next;
            LinkedListNode<BuffInfo> prev = current.Previous;

            while (prev != null && prev.Value.buffData.Priority > current.Value.buffData.Priority)
            {
                prev = prev.Previous;
            }
            if (prev == null)
            {
                list.Remove(current);
                list.AddFirst(current);
            }
            else
            {
                list.Remove(current);
                list.AddAfter(prev, current);
            }
            current = next; 
        }
    }
}
