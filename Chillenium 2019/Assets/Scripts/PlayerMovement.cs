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
    private const float AIR_MOVEMENT = 0.1f;
    private float moveSpeed;

    //Constant for jumping
    private const float JUMP_FORCE = 200f;

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
    void Update()
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
        if (Input.GetKey("d") && !playerCollision.rightWalled)              //Move right     
            player.position += Vector3.right * moveSpeed;

        if (Input.GetKey("a") && !playerCollision.leftWalled)               //Move left
            player.position += Vector3.left * moveSpeed;

        if (Input.GetKeyDown("space") && playerCollision.grounded)          //Jump
            GetComponent<Rigidbody>().AddForce(Vector3.up * JUMP_FORCE);

    }
}