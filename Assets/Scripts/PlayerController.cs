using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float defaultMoveSpeed;
    public float increaseSpeedFactor;   //increase speed multiplier by amount. example 1.01 for a 1% increase in speed
    public float speedIncreaseGoal;    //increase player speed after reaching certain distance(x)
    private float defaultspeedIncreaseGoal;
    public float speedIncreaseCounter;
    private float defaultSpeedIncreaseCounter;

    public float jumpForce;
    private bool isPlayerNotJumping;
    private bool allowDoubleJump;
    public float jumpHoldTime;
    private float jumpHoldTimeCnt;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform feetOnGroundOnly;
    public float feetOnGroundRadius;

    private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager myGameManager;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        jumpHoldTimeCnt = jumpHoldTime; //default counter for holding jump time
        defaultMoveSpeed = moveSpeed;   //default start setting for moveSpeed
        speedIncreaseCounter = speedIncreaseGoal;   //default start setting for increase counter
        defaultSpeedIncreaseCounter = speedIncreaseCounter; //default start setting for speedIncreaseCounter
        defaultspeedIncreaseGoal = speedIncreaseGoal;   //default start setting for for goal
        isPlayerNotJumping = true;  //default start, player is on ground, not jumping
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
                isPlayerNotJumping = false;     //player is on ground, not jumping
            }

            if(GameManagerSingleton.Instance.player.doubleJump) { //check game singleton if doubleJump highscore goal has been reached and is enabled
                if(!grounded && allowDoubleJump)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);  //jump used as inputs of keyboard space or primary mouse button
                    jumpHoldTimeCnt = jumpHoldTime; //allow 2nd jump to hold in air for longer jump
                    isPlayerNotJumping = false;     //player is not on ground when button is pressed
                    allowDoubleJump = false;    //allows only one double jump per button press
                }
            }
        }

        if (GameManagerSingleton.Instance.player.longJump)  //check game singleton if longJump highscore goal has been reached and is enabled
        { 
            if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetMouseButton(0)) && !isPlayerNotJumping)  //hold down jump button for longer jump
            {
                if (jumpHoldTimeCnt > 0)
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    jumpHoldTimeCnt = jumpHoldTimeCnt - Time.deltaTime;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetMouseButtonUp(0))    
        {
            jumpHoldTimeCnt = 0;    //detect release of jump key, prevents unintended double jumping/unintended jumping length
            isPlayerNotJumping = true;
        }

        if (grounded)   //reset counter for jump time
        {
            jumpHoldTimeCnt = jumpHoldTime; //player touches the ground, reset jump in air time counter
            allowDoubleJump = true;     //allowing double jump
        }

        myAnimator.SetFloat("Speed", myRigidbody.velocity.x);  //speed value to use in the animator
        myAnimator.SetBool("Ground", grounded);  //is player grounded or not to use in the animator

        //enable bonus based on high score within game
        if (GameManagerSingleton.Instance.player.currentHighScore > 500)
        {
            GameManagerSingleton.Instance.player.longJump = true;
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 2500)
        {
            GameManagerSingleton.Instance.player.doubleJump = true;
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 10000)
        {
            GameManagerSingleton.Instance.player.trapMaster = true;
        }

        if (GameManagerSingleton.Instance.player.currentHighScore > 20000)
        {
            GameManagerSingleton.Instance.player.beastMaster = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)      //when two objects touch each other
    {
        if (collision.gameObject.tag == "touchGameOver")        //added tag to box collider 2d for any objects that cause player game over
        {

            moveSpeed = defaultMoveSpeed;   //reset to default move speed
            speedIncreaseCounter = defaultSpeedIncreaseCounter;     //reset counter
            speedIncreaseGoal = defaultspeedIncreaseGoal;   //reset goal
            myGameManager.Restart();    //restart game

        }
    }
}
