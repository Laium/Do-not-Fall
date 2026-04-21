using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public bool onGround;
    public Rigidbody2D rb;
    private float moveInput;
    public float walkSpeed;
    public LayerMask groundMask;
    public float jumpValue = 0.0f;
    public PhysicsMaterial2D bounceMat, playerMat;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // Receives horizontal inputs for horizontal movement
        onGround = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, groundMask); // Determines when the player collides with a platform

        if (jumpValue == 0.0f && onGround) 
        {
            rb.velocity = new Vector2(moveInput * walkSpeed, rb.velocity.y); 
        }
        // If Statement for horizontal movement where when the jumpValue is 0 and the object is in contact with a platform (onGround)
        // the player will move with horizontal velocity with no added vertical velocity for linear horizontal movement. This script
        // later inhibits the player from moving while charging a jump.

        if (jumpValue > 0)   
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = playerMat;
        }
        // The If else statement above changes the players material properties from
        
        if (Input.GetKey("space") && onGround)
        {
            jumpValue += 0.2f;
            walkSpeed = 16.0f;
        
        }

        if (Input.GetKeyDown("space") && onGround) // Charging of the power of the jump
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y); 
        }
        if (jumpValue >= 40.0f && onGround) // Limits the amount of force the player can jump at.
        {

            float tempx = moveInput * walkSpeed; // Horizontal velocity component multiplied by the walkSpeed/movementspeed to set direction
            float tempy = jumpValue; // Vertical velocity component
            rb.velocity = new Vector2(tempx, tempy); // Uses a temporary value to be stored for the velocity of the veritcal and horizontal components to be replaced once space is pressed again.
            Invoke("ResetJump", 0.2f);

        }
        if (Input.GetKeyUp("space") && onGround)    // When the player releases the space bar the charged velocity is released and no extra jump velocity is added
        {

            rb.velocity = new Vector2(moveInput * walkSpeed, jumpValue);
            Invoke("ResetJump", 0.2f);
        }
    }
    void ResetJump()    // Function that stops the player from jumping in the air and adding extra jump velocity during the jump.
    {
        onGround = false;
        jumpValue = 0.0f;
        walkSpeed = 10.0f;

    }
    void onDrawGizmosSelected() // Code to display the player hitbox and interaction with platforms
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f), new Vector2(0.9f, 0.2f));
    }

}
