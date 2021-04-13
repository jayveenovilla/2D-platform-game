using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);  //use 2d phsyics to determine if player is touching the ground

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);  //set velocity for player to be constantly moving forward

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
        {
            if (grounded)  //only able to jump if touching the ground
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);  //jump used as inputs of keyboard space or primary mouse button
            }
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);  //speed value to use in the animator
        myAnimator.SetBool("Ground", grounded);  //is player grounded or not to use in the animator
    }
}
