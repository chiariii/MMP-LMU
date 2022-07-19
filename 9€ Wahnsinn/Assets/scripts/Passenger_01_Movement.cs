using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger_01_Movement : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    private Vector2 screenBounds;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        rb.velocity = new Vector2(0, speed);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    // Update is called once per frame
    void Update()
    {
        
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
       
        movement.x = 0;
        movement.y = -transform.position.y; 
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //if (movement.y > screenBounds.y * 2)
        Debug.Log(movement.sqrMagnitude);
        if (movement.sqrMagnitude <= 0.001f)
        {
           Debug.Log(movement.sqrMagnitude);
           Destroy(this.gameObject);
        }
        
    }

    void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
