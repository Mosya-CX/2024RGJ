using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "创建新的敌人" , fileName = "newEnemy")]
public class BaseEnemy : ScriptableObject
{
    public float speed;
    public float maxHealth;
    public int damage;
    public float attackDist;// 攻击距离
    public BaseAttack attackAction;
}
