using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{

    GameObject[] enemies;
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
            Destroy(locked);
        }
    }
}
