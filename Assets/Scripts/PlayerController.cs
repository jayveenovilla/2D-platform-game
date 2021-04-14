﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float increaseSpeedFactor;   //increase speed multiplier by amount. example 1.01 for a 1% increase in speed
    public float speedIncreaseGoal;    //increase player speed after reaching certain distance(x)
    public float speedIncreaseCounter;

    public float jumpForce;

    public float jumpHoldTime;
    private float jumpHoldTimeCnt;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform feetOnGroundOnly;
    public float feetOnGroundRadius;

    private Collider2D myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpHoldTimeCnt = jumpHoldTime; //default counter for holding jump time
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);  //use 2d phsyics to determine if player is touching the ground
        grounded = Physics2D.OverlapCircle(feetOnGroundOnly.position, feetOnGroundRadius, whatIsGround); //use 2d phsyics to determine if player is touching the ground of a smaller radius near player feet

        if (transform.position.x > speedIncreaseCounter)    //increase player speed after reaching certain distance(x) determined by a counter
        {
            speedIncreaseCounter = speedIncreaseCounter + speedIncreaseGoal;    //increment the speed increase counter
            speedIncreaseGoal = speedIncreaseGoal * increaseSpeedFactor + speedIncreaseGoal;    //increase distance required to reach next speed boost since the distance will be covered faster with the new speed
            moveSpeed = moveSpeed * increaseSpeedFactor;    //increase the movespeed
        }

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);  //set velocity for player to be constantly moving forward

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
        {
            if (grounded)  //only able to jump if touching the ground
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);  //jump used as inputs of keyboard space or primary mouse button
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetMouseButton(0))  //hold down jump button for longer jump
        {
            if(jumpHoldTimeCnt > 0)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpHoldTimeCnt = jumpHoldTimeCnt - Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetMouseButtonUp(0))    //detect release of jump key, prevents double jumping/unintended jumping length
        {
            jumpHoldTimeCnt = 0;
        }

        if (grounded)   //reset counter for jump time
        {
            jumpHoldTimeCnt = jumpHoldTime;
        }

            myAnimator.SetFloat("Speed", myRigidbody.velocity.x);  //speed value to use in the animator
        myAnimator.SetBool("Ground", grounded);  //is player grounded or not to use in the animator
    }
}
