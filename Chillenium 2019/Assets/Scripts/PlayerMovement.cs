using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Reference Variables
    private CollisionSystem playerCollision;
    private Transform player;
    private Vector3 spawnPoint;
    //Constants and variables for horizontal movement
    private const float GROUNDED_MOVEMENT = 0.15f;
    private const float AIR_MOVEMENT = 0.075f;
    private float moveSpeed;

    //Constant for jumping
    private const float JUMP_FORCE = 25f;

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
        if (Input.GetKey("d") )              //Move right     
            player.position += Vector3.right * moveSpeed;

        if (Input.GetKey("a"))               //Move left
            player.position += Vector3.left * moveSpeed;

        if (Input.GetKey("space") && playerCollision.grounded)
        {          //Jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * JUMP_FORCE);
            playerCollision.grounded = false;
        }
    }
}