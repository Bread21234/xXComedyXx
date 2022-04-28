using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;
    public GameObject Destroyer;

    public float waitTime;
    private bool spawnedBossSpawner;
    public GameObject bossSpawner;
   // public GameObject player1;

    private NextLevel nextLevel;

    void Start()
    {
        NextLevel nextLevel = GameObject.FindWithTag("Level Handler").GetComponent<NextLevel>();
        nextLevel.levelUp();
        StartCoroutine(nextLevel.holdPlease());
    }

    void Update(){
        if(waitTime <= 0 && spawnedBossSpawner == false){
                Instantiate(Destroyer, rooms[rooms.Count-1].transform.position, Quaternion.identity);
                Instantiate(bossSpawner, rooms[rooms.Count-1].transform.position, Quaternion.identity);
           //    Instantiate(player1, rooms[0].transform.position, Quaternion.identity);
               spawnedBossSpawner = true;
               waitTime = 0;
       } else{
           waitTime -= Time.deltaTime;
       }
   }
}
