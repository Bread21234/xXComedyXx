using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

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
            Destroy(gameObject);
        }
    }
}
