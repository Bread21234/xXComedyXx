using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public Transform Gun;

    Vector2 direction;

    public GameObject Bullet;

    public float BulletSpeed;

    public Transform ShootPoint;

    public float fireRate;

    public float ReadyforNextShot;

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
    }
    void FixedUpdate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();

        if(Input.GetMouseButton(0))
        {
            if(Time.time > ReadyforNextShot){
                ReadyforNextShot = Time.time + 1/fireRate;
                shoot();
            }     
        }
    }
    void FaceMouse()
    {
        Gun.transform.right = direction;
    }
    void shoot()
    {
        GameObject BulletIns = Instantiate(Bullet,ShootPoint.position,ShootPoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed); //this doesnt seem to create issue with pushing player
    }
}