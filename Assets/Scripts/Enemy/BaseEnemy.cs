using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "�����µĵ���" , fileName = "newEnemy")]
public class BaseEnemy : ScriptableObject
{
    public float speed;
    public float maxHealth;
    public int damage;
    public float attackDist;// ��������
    public BaseAttack attackAction;
}
