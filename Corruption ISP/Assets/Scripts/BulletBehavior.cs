using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //public GameObject impactEffect;

   // public float speed = 20f;

    public Rigidbody2D rb;
    
    public int damage = 40;

       //playerHealth player = hitInfo.GetComponent<playerHealth>();
        //ShootScript gun = hitInfo.GetComponent<ShootScript>();
        //BulletBehavior bullet = hitInfo.GetComponent<BulletBehavior>();
        //if (player == null && gun == null && bullet == null){ //ignores those two things
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>(); //HERHEHREHHREHRHEHREHHREHRHERHED
        if (enemy != null || hitInfo.CompareTag("Obstacle") == true){
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
