using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{

    Rigidbody2D rb2d;

    private float horizontal;
    private float vertical;

    public float forwardSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        var velocity = rb2d.velocity;
        if (Input.GetKey("w"))
        {
            rb2d.velocity = new Vector2(horizontal * forwardSpeed, vertical * forwardSpeed);
        }

        if (Input.GetKey("s"))
        {
            rb2d.velocity = new Vector2(horizontal * -forwardSpeed, vertical * -forwardSpeed);
        }

        else
        {
            rb2d.velocity = new Vector2(0, 0);
        }
    }
}
