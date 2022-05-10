using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    public GameObject hitEffect;

    public Rigidbody2D rb;
    
    public int damage = 40;

  void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>(); //HERHEHREHHREHRHEHREHHREHRHERHED
        if (enemy != null || hitInfo.CompareTag("Obstacle") == true){
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(hitEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
