using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] weapons; //array of the weapons 
    private int rand;

    public GameObject OpenChest; //setting the open chest that will be created upon opening the chest

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        if (player != null)
        {
            Vector3 newposition = gameObject.transform.position + new Vector3(0,1000,0);
            rand = Random.Range(0,weapons.Length); //getting a radom index to then get a random weapon from the array
            Instantiate(weapons[rand],gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject); //destroying original chest 
            Instantiate(OpenChest,gameObject.transform.position,Quaternion.identity); //creating opened chest
        }
    }
}
