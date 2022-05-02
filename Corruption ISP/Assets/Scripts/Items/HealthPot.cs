using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    public int amount;

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if (player != null)
        {
            player.gainHealth(amount);
            Destroy(gameObject);
        }
    }
}
