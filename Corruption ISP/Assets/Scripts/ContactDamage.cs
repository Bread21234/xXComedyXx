using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
