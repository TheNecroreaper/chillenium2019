using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public AudioSource deathNoise;

    private bool destroy = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(destroy)
            Destroy(gameObject);
    }

    public void Destroy()
    {

        destroy = true;
    }
}
