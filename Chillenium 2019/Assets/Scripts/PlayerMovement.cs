using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    //Reference Variables
    private CollisionSystem playerCollision;
    private Transform player;
    private Vector3 spawnPoint;
    public GameObject trigger;
    private Floating floatScript;
    private attackTrigger attackScript;
    //Constants and variables for horizontal movement
    private const float GROUNDED_MOVEMENT = 0.15f;
    private const float AIR_MOVEMENT = 0.075f;
    private float moveSpeed;

    private bool facing = true;

    //Constant for jumping
    private const float JUMP_FORCE = 40f;

    // Use this for initialization
    void Start()
    {
        setVars();
    }

    public void setVars()
    {
        playerCollision = GetComponent<CollisionSystem>();
        player = GetComponent<Transform>();
        spawnPoint = player.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Set status
        if (playerCollision.grounded)
        {
            moveSpeed = GROUNDED_MOVEMENT;
        }
        else
        {
            moveSpeed = AIR_MOVEMENT;
        }

        //Controls
        if (Input.GetKey("d"))
        {             //Move right     
            if (!facing)
            {
                flip();
            }
            player.position += Vector3.right * moveSpeed;
            facing = true;
        }
        if (Input.GetKey("a"))
        {               //Move left'
            if (facing)
            {
                flip();
            }
            player.position += Vector3.left * moveSpeed;
            facing = false;
        }
        if (Input.GetKey("space") && playerCollision.grounded)
        {          //Jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * JUMP_FORCE);
            playerCollision.grounded = false;
        }
        if(Input.GetKeyDown("q"))
        {
            floatScript.enabled = !floatScript.enabled;
            attackScript.enabled = !floatScript.enabled;
        }
    }

    private void flip()
    {
        //transform.localScale = new Vector2(-1, transform.localScale.y);
        trigger.transform.Translate( new Vector3(facing? -1.5f: 1.5f, 0, 0));
    }

}