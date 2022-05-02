using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickedUpGun : MonoBehaviour
{
    public Transform Gun;
    void Update(){
        if (!Gun.parent)
            {
                Gun.GetComponent<ShootScript>().enabled = false;
            }else{
                Gun.GetComponent<ShootScript>().enabled = true;
        }
    }
}
