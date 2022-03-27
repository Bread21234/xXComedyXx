using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //public GameObject impactEffect;

   // public float speed = 20f;

    public Rigidbody2D rb;
    
    public int damage = 40;

   // void Start ()
   // {
   //     rb.velocity = transform.right * speed; //seems to push player 
   // }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        //Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
