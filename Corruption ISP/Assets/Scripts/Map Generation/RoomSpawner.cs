using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
  
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject,waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if(spawned == false){ //checks if a room has already been spawned at this location
            if(openingDirection == 1){
                rand = Random.Range(0, templates.bottomRooms.Length); //gets a random index
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation); //spawns a random corelating room
            } else if(openingDirection == 2){
                rand = Random.Range(0, templates.topRooms.Length); //gets a random index
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation); //uses that index and spawns a random correlating room
            } else if(openingDirection == 3){
                rand = Random.Range(0, templates.leftRooms.Length); //random index
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            } else if(openingDirection == 4){
                rand = Random.Range(0, templates.rightRooms.Length); //random index
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawn Point"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false) // if neither spawn point has spawned a room
            {
                //spawn walls blocking off opening
                templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
                Instantiate(templates.closedRooms, other.transform.position, Quaternion.identity); //creates the blank room
                Destroy(gameObject); //destroys spawn point
            }
            spawned = true;
        }
        if(other.CompareTag("Destroyer"))
        { 
                Destroy(gameObject);
        }
        spawned = true;
    }
}
