using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other){
        EnemySpawner enemySpawner = other.GetComponent<EnemySpawner>();
        RoomSpawner roomSpawner = other.GetComponent<RoomSpawner>();
        if(roomSpawner != null || enemySpawner != null){
        Destroy(other.gameObject);
        }
        if (other.CompareTag("Obstacle"))
        {
            Destroy(other);
        }
    }
    
}
