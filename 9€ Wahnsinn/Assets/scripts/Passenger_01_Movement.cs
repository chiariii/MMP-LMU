using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger_01_Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    //public Damage health;
    Vector2 movement;
    private Vector2 screenBounds;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        rb.velocity = new Vector2(0, speed);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    
    void Update()
    {
       
        movement.x = 0;

        if(transform.position.y < 0){
            movement.y = -transform.position.y;
        }else if(transform.position.y > 0){
            movement.y = transform.position.y;
        }

        if(transform.position.y > 1){
            Destroy(this.gameObject);
            //health.TakeDamage(10);
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        
        
    }


}
