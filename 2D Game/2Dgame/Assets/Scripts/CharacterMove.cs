using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    //player movement variables
    public int moveSpeed;
    public float jumpHeight;
    private bool doubleJump;

    //Player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //Non-Slide Player
    private float moveVelocity;

    // Use this for initialization
    void Start () {
        
    }
    
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    
    // Update is called once per frame
    void Update () {

        //this code makes the character jump
        if(Input.GetKeyDown (KeyCode.W)&& grounded){
            Jump();
        }

        // Double jump code
        if(grounded)
            doubleJump = false;

        if(Input.GetKeyDown (KeyCode.W)&& !doubleJump && !grounded){
            Jump();
            doubleJump = true;
        }
        //Non-Slide Player
        moveVelocity = 0f;

	   // this code makes the character move from side to side usinng the ASD keys
	    if(Input.GetKey (KeyCode.D)){
		   //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
           moveVelocity = moveSpeed;
        }
        if(Input.GetKey (KeyCode.A)){
		   //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
           moveVelocity = -moveSpeed;
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);


    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}

