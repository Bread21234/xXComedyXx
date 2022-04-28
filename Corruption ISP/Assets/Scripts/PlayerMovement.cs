using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float moveSpeed = 10f;

    public Rigidbody2D rb;

    Vector2 movement;
    public Animator animator;
  
    public float scale;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if(movement.x >= 0.01f) //turn around
        {
      //    transform.localScale = new Vector3(scale, scale, scale);
        } else if(movement.x <= -0.01f)
        {
       //   transform.localScale = new Vector3(-1*scale, scale, scale);
        }
    }

    private void OnLevelWasLoaded(int Level)
    {
      FindStartPos();
    }

    void FindStartPos()
    {
      transform.position = GameObject.FindWithTag("Start Position").transform.position;
    }
}
