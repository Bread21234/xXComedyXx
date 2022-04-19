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
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        ShootScript gun = hitInfo.GetComponent<ShootScript>();
        if (player == null && gun == null){ //ignores those two things
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            // Debug.Log(enemy);
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            //Instantiate(impactEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
