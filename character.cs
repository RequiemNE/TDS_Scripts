using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    public Camera cam;
    public GameObject crossHair;
    public float aimDistance = 8f;

    Vector2 movement;
    Vector2 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Cursor.visible = false;

    }

    private void FixedUpdate()
    {
        Movement();

        Shooting();
    }


    private void Shooting()
    {
        crossHair.transform.position = Vector2.MoveTowards(transform.position, mousePos, aimDistance);

        crossHair.transform.rotation = transform.rotation;
    }

    private void Movement()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
