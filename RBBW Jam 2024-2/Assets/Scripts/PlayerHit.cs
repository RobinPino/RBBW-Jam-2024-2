using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHit : MonoBehaviour, IDamagable
{
    private int Health;
    [SerializeField] int MaxHealth;
    [SerializeField] EventChannelSO playerHitChannel;
    [SerializeField] EventChannelSO playerDeathChannel;

    private void Start()
    {
        Health = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died");
    }
}
