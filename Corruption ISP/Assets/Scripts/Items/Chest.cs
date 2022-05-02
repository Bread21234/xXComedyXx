using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] weapons;
    private int rand;

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if (player != null)
        {
            rand = Random.Range(0,weapons.Length);
            Instantiate(weapons[rand],gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
