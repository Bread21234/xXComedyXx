using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // make a collision detector right at the beginning of each door
    //find a random location within a range of ten instantiate a random enemy much like the boxes. 

    public GameObject[] enemies;
    public int enemyNumber = 2;

    public GameObject LockedRoom;
    public bool spawnedRoom = false;


    private int xOffset;
    private int yOffset;
    private Vector3 offset;
    private int randEnemy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && spawnedRoom == false) //if the room has not been used yet and the player enters
        {
            Instantiate(LockedRoom,transform.position,Quaternion.identity); //instantiates the doors
            
            for (int i = 0; i <= enemyNumber; i++){ //loops based on how many floors the player has been on
                xOffset = Random.Range(-200,200); //random x cord
                yOffset = Random.Range(-200,200); //random y cord 
                offset = new Vector3(xOffset,yOffset,0); 
                randEnemy = Random.Range(0, enemies.Length); //random enemy from selection
                Instantiate(enemies[randEnemy], transform.position + offset, Quaternion.identity); //create the enemy
            }
            spawnedRoom = true; //ensures the room won't spawn more enemies
        }
    }
    public void addEnemies(int idk)
    {
        //Debug.Log("Please have mercy");
        enemyNumber += idk;
    }

    IEnumerator instantiateEnemies()
    {
        yield return new WaitForSeconds(1f);
        xOffset = Random.Range(-200,200);
        yOffset = Random.Range(-200,200);
        offset = new Vector3(xOffset,yOffset,0);
        randEnemy = Random.Range(0, enemies.Length);
        Instantiate(enemies[randEnemy], transform.position + offset, Quaternion.identity);
    }
}
