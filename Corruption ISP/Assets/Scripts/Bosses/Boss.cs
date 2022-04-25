using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 100;

    public GameObject deathEffect;
    public GameObject LevelLoader;

    public void TakeDamage (int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
     void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(LevelLoader, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (gameObject.transform.parent != null)
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
