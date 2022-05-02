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
        if (enemies.Length == 0){
            unLockRoom();
        }
    }
    void unLockRoom(){
        
        GameObject[] lockedRoom = GameObject.FindGameObjectsWithTag("LockedRoom");
        foreach(GameObject locked in lockedRoom){
            randSpawnItem = Random.Range(1,5);
            if (randSpawnItem == 2)
            {
                whichItem = Random.Range(0,items.Length);
                Instantiate(items[whichItem],locked.transform.position,Quaternion.identity);
            }
            Destroy(locked);
        }
    }
}
