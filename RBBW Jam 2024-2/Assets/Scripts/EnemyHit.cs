using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour, IDamagable
{
    private int Health;
    ShapeBehaviour shapeBehaviour;
    [SerializeField] EventChannelSO enemyHitChannel;
    [SerializeField] EventChannelSO enemyDeathChannel;

    private void Start()
    {
        shapeBehaviour = GetComponent<ShapeBehaviour>();
        Health = shapeBehaviour.shape.health;
    }

    public void TakeDamage(int damage)
    {
        enemyHitChannel.Invoke(this);
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
        Debug.Log("Enemy took " + damage + " damage");
    }

    void Die()
    {
        enemyDeathChannel.Invoke(this);
        Destroy(gameObject);
    }
}

