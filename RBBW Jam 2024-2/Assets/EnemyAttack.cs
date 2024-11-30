using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform targetPosition;
    [SerializeField] PlayerHit playerHit;

    [SerializeField] float AttackRange;
    [SerializeField] int Damage;
    [SerializeField] float AttackCooldown;
    float lastAttackTime;
    private void Update()
    {
        print(Vector3.Distance(targetPosition.position, transform.position));
        if(Vector3.Distance(targetPosition.position, transform.position) <= AttackRange)
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        if(Time.time - lastAttackTime < AttackCooldown)
        {
            return;
        }

        lastAttackTime = Time.time;
        playerHit?.TakeDamage(Damage);
    }
}
