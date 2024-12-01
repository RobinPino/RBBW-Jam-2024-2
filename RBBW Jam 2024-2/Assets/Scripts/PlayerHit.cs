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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Player Hit!");

            Destroy(collision.gameObject);

            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        playerHitChannel.Invoke(this);
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
