using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public GameObject[] items; //healthpots ammo? other stuff
    private int randSpawnItem;
    private int whichItem;

    public GameObject[] enemies;
    //public Text enemyCountText;
    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //enemyCountText.text = "Enemies : " + enemies.Length.ToString();
        if (enemies.Length <= 0){
            unLockRoom();
        }
    }
    void unLockRoom(){
        
        GameObject[] lockedRoom = GameObject.FindGameObjectsWithTag("LockedRoom"); //finds all the locked rooms
        foreach(GameObject locked in lockedRoom){
            randSpawnItem = Random.Range(1,3); //ramdom to decide if an item should be spawned
            if (randSpawnItem == 2)
            {
                whichItem = Random.Range(0,items.Length); //deciding which item to spawn
                Instantiate(items[whichItem],locked.transform.position,Quaternion.identity); //spawning an item with the idex
            }
            Destroy(locked); //unlocking the room
        }
    }
}
