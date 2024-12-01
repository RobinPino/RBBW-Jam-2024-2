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

    public AudioSource DeathSound;

    private void Start()
    {
        Health = MaxHealth;
        DeathSound = GetComponent<AudioSource>();
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
        playerHitChannel.Invoke(this);

        if (Health <= 0)
        {
            Die();
        }

        Health -= damage;
    }

    public void Die()
    {
        Debug.Log("Player died");
        DeathSound.Play();
    }
}
