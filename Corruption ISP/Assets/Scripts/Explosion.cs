using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public Rigidbody2D rb;
    
    public int damage = 40;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("Step 1");
        Enemy enemy = hitInfo.GetComponent<Enemy>(); //HERHEHREHHREHRHEHREHHREHRHERHED
        Debug.Log(enemy);
            //if (enemy != null){
        if (enemy != null)
        {
        //        Debug.Log("explosion attempt1");
                enemy.TakeDamage(damage);
        }
    }
}