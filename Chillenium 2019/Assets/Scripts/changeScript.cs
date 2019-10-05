using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScripy : MonoBehaviour
{
    public Sprite rectangle, rectangle2, rectangle3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            this.GetComponent<SpriteRenderer>().sprite = rectangle;
        if (Input.GetKey(KeyCode.E))
            this.GetComponent<SpriteRenderer>().sprite = rectangle2;
        if (Input.GetKey(KeyCode.R))
            this.GetComponent<SpriteRenderer>().sprite = rectangle3;
    }
}
