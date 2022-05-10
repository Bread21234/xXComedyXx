using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 playerPos;
    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindWithTag("Player").transform.position;
        if (playerPos != null){
            transform.position = new Vector3(playerPos.x,playerPos.y,-10);
        }
    }
}
