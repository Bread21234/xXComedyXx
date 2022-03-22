using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float moveSpeed = 10f;

    public Rigidbody2D rb;
  //  public Camera cam;

    Vector2 movement;
   // Vector2 mousePos; //mousestuff

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //mouse stuff
      //  mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        //mouse stuff
       // Vector2 lookDir = mousePos - rb.position;
      //  float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
       // rb.rotation = angle;
    }
}
