using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 5; //speed in units per seconds
    private Rigidbody2D rb2d;   //Compponent which has to be added to the player in the inspector

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if(rb2d == null)
        {
            Debug.LogError("No rigidbody was assigned to player!");
        }
    }

    //FixedUpdate is a alternative Methode which should be used instead of Update if we are working with unity physics for example with the rigidbody movement
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get movement input of ASDW / Arrows or Joystick x = xAxis (left right), y = YAxisn (up down)

        movement.Normalize(); //make sure that if X and Y are both 1 (i.e. (-1, -1) the lenght of the vector is still equal to 1 (comment this liine out and compare diagonal movement speed compared to horizontal to see what I mean)

        if (Mathf.Abs(movement.magnitude) > 0.1f)
        {
            movement *= Time.fixedDeltaTime * Speed;
            rb2d.MovePosition(rb2d.position + movement);
        }
    }
}
