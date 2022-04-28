using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterAI : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        
        changeDirection(player.position);

        if(timeBtwShots <= 0)
        {  
            StartCoroutine(animateShot());
            timeBtwShots = startTimeBtwShots;
        } else {
            timeBtwShots -= Time.deltaTime;
        }
    }
    IEnumerator animateShot(){
        animator.SetBool("CurrentlyShooting",true);
        yield return new WaitForSeconds(.5f);
        animator.SetBool("CurrentlyShooting",false);
         Instantiate(projectile, transform.position, Quaternion.identity);
    } 
       void changeDirection(Vector3 position){
        if(player.position.x > transform.position.x) //turn around
        {
            transform.localScale = new Vector3(200, 200, 200);
        } else if(player.position.x < transform.position.x)
        {
            
            transform.localScale = new Vector3(-1*200, 200, 200);
        }
    }
}
