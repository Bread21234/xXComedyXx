using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 500;
    public int damage;
    private float timeBtwDamage = 1.5f;

    public Animator redPanel;
    public Animator camAnim;
    //public slider healthbar;

    public GameObject deathEffect;
    public GameObject LevelLoader;

    private void Update()
    {
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
       // healthbar.value = health;
    }

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
