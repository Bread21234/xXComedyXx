using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
 public Transform Gun;
    Vector2 direction;

    public Transform ShootPoint;
    public GameObject Bullet;
    public float BulletSpeed;
    public float fireRate;
    public float ReadyforNextShot;


    public Animator animator;
    private bool isReloading = false;

  // reloading
    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime = 5f;

    private Transform player;  
    void Start()
    {   
        player = GameObject.FindWithTag("Player").transform;

        currentAmmo = maxAmmo;
        if (currentAmmo == -1)
            currentAmmo = maxAmmo;
    }
    //end reload

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

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {   
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetMouseButton(0))
        {
            if(Time.time > ReadyforNextShot){
                ReadyforNextShot = Time.time + 1/fireRate;
                shoot();
            }     
        }
    }
       void OnEnable(){
        isReloading = false;
        //animator.SetBool("Reloading",false);
    }
    void FaceMouse()
    {
        if (Gun.parent != null){
            Gun.transform.right = direction;
        }
        if(direction.x >= 0.01f)
        {
            player.localScale = new Vector3(200,200,1);
            transform.localScale = new Vector3(7,7,1);
        } else if(direction.x <= -0.01f)
        {
            player.localScale = new Vector3(-200,200,1);
            transform.localScale = new Vector3(-7,-7,1);
        }
    }
    void shoot()
    {
        if (Gun.parent != null){
            currentAmmo--; //removing a bullet
      
            for (int i = 0; i <= 2; i++)
            {
                var BulletIns = Instantiate(Bullet,ShootPoint.position,ShootPoint.rotation);

                switch (i)
                {
                    case 0:
                        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed + new Vector3(0f,-90f,0f));
                        break;
                    case 1:
                        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed + new Vector3(0f,0,0f));
                        break;
                    case 2:
                        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed + new Vector3(0f,90f,0f));
                        break;
                }
            }  
        }   
    }
    IEnumerator Reload() 
    {
        isReloading = true;
        
     //   Debug.Log("reloading");

        //animator.SetBool("Reloading",true); animations

        yield return new WaitForSeconds(reloadTime -.25f);

        //animator.SetBool("Reloading",false) animations

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false; 
    }
}
