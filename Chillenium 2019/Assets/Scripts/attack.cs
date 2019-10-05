using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

    private AudioSource hitSound;
    private AudioSource deathNoise;
    void Start()
    {
        AudioSource[] sounds = GetComponents<AudioSource>();
        hitSound = sounds[0];
        deathNoise = sounds[1];
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.isTrigger != true && other.CompareTag("Enemy"))
        {
            deathNoise.time = .6f;
            deathNoise.Play();
            hitSound.Play();
            other.SendMessageUpwards("Destroy");
        }     
    }
}
