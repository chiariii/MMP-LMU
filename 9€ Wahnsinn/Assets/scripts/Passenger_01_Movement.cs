using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger_01_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    //public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        /*
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        animator.setFloat("Horizontal", movement.x);
        animator.setFloat("Vertical", movement.y);
        animator.setFloat("Speed", movement.sqrMagnitude);
        */
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
