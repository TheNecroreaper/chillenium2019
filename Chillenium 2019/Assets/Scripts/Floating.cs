using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    private Rigidbody player;
    private CollisionSystem playerCollision;

    private float timeFloat = 1f;
    private float floatTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        playerCollision = GetComponent<CollisionSystem>();
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerCollision.grounded && Input.GetKey("space") && player.velocity.y < 0 && floatTimer > 0)
        {
            GetComponent<ConstantForce>().force = new Vector3(0, 10.0f, 0);
            floatTimer -= Time.deltaTime;
        }
        else
        {
            GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            if (playerCollision.grounded)
                floatTimer = timeFloat;
        }
    }
}
