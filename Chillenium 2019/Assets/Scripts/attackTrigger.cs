using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackTrigger : MonoBehaviour
{
    private bool attacking = false;

    private float cdTimer = 0.3f;
    private float attackTimer = 0;

    public Collider trigger;

    private Animator anim;

    private AudioSource attackSound;

    private void Awake()
    {
        trigger.enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        attackSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && !attacking)
        {
            attackSound.time = 0.2f;
            attackSound.Play();
            attacking = true;
            attackTimer = cdTimer;
            
            trigger.enabled = true;

        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
    }
}
