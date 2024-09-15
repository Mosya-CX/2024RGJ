using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "创建投掷物效果/1000", fileName = "MissleEffect1000")]
public class MissleEffect1000 : MissileEffect
{
    public float angleOffset = 5;
    public override void BaseApply(MissileInfo info, Vector3 dir)
    {
        bool tmp = false;
        for (int i = 0; i < info.number; i++)
        {
            GameObject obj = null;
            if (tmp)
            {
                obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir) + ((i + 1) / 2) * angleOffset));
            }
            else
            {
                obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir) - ((i + 1) / 2) * angleOffset));
            }
            tmp = !tmp;
            obj.transform.localScale *= info.size;
            // 获得子弹脚本
            Bullet1000 bullet = obj.GetComponent<Bullet1000>();
            bullet.speed = info.speed;
            bullet.damage = info.damage;
            bullet.duration = info.durationTime;
        }
    }

    public override void GoodApply(MissileInfo info, Vector3 dir)
    {
        bool tmp = false;
        for (int i = 0; i < info.number; i++)
        {
            GameObject obj = null;
            if (tmp)
            {
                obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir) + ((i + 1) / 2) * angleOffset));
            }
            else
            {
                obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir) - ((i + 1) / 2) * angleOffset));
            }
            tmp = !tmp;
            obj.transform.localScale *= info.size;
            // 获得子弹脚本
            Bullet1000 bullet = obj.GetComponent<Bullet1000>();
            bullet.speed = info.speed;
            bullet.damage = info.damage;
            bullet.duration = info.durationTime;
        }
    }

    public override void NonApply(MissileInfo info, Vector3 dir)
    {
        bool tmp = false;
        for (int i = 0; i < info.number; i++)
        {
            GameObject obj = null;
            if (tmp)
            {
                obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir) + ((i + 1) / 2) * angleOffset));
            }
            else
            {
                obj = Instantiate(info.missileData.prefabe, GameManager.Instance.playerData.transform.position + dir * 2, Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, dir) - ((i + 1) / 2) * angleOffset));
            }
            tmp = !tmp;
            obj.transform.localScale *= info.size;
            // 获得子弹脚本
            Bullet1000 bullet = obj.GetComponent<Bullet1000>();
            bullet.speed = info.speed;
            bullet.damage = info.damage;
            bullet.duration = info.durationTime;
        }
    }

    public override void GreatApply(MissileInfo info, Vector3 dir)
    {
        throw new System.NotImplementedException();
    }

    public override void PrefectApply(MissileInfo info, Vector3 dir)
    {
        throw new System.NotImplementedException();
    }
}
