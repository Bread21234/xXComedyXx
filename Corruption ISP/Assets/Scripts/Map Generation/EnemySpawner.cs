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
        if(other.CompareTag("Player") && spawnedRoom == false)
        {
            Instantiate(LockedRoom,transform.position,Quaternion.identity);
            
            for (int i = 0; i <= enemyNumber; i++){
                xOffset = Random.Range(-100,100);
                yOffset = Random.Range(-100,100);
                offset = new Vector3(xOffset,yOffset,0);
                randEnemy = Random.Range(0, enemies.Length);
                Instantiate(enemies[randEnemy], transform.position + offset, Quaternion.identity);
            }
            spawnedRoom = true;
        }
    }
    public void addEnemies(int idk)
    {
        enemyNumber += idk;
    }
}
