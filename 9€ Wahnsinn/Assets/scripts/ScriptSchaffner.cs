using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSchaffner : MonoBehaviour
{

    Rigidbody2D rb;

    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    Vector2 movement;

    private Animator anim;


    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(inputVertical < 0 && inputHorizontal == 0)
        {
            anim.SetBool("IsSouth", true);
            anim.SetBool("IsNorth", false);
            anim.SetBool("IsEast", false);
            anim.SetBool("IsWest", false);
        }
        else if(inputVertical > 0 && inputHorizontal == 0)
        {
            anim.SetBool("IsSouth", false);
            anim.SetBool("IsNorth", true);
            anim.SetBool("IsEast", false);
            anim.SetBool("IsWest", false);
        }
        else if(inputHorizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);	
            anim.SetBool("IsSouth", false);
            anim.SetBool("IsNorth", false);
            anim.SetBool("IsEast", true);
            anim.SetBool("IsWest", false);
        }
        else if(inputHorizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);	
            anim.SetBool("IsSouth", false);
            anim.SetBool("IsNorth", false);
            anim.SetBool("IsEast", true);
            anim.SetBool("IsWest", false);
        }
        else 
        {
            anim.SetBool("IsSouth", false);
            anim.SetBool("IsNorth", false);
            anim.SetBool("IsEast", false);
            anim.SetBool("IsWest", false);
        }
    }

    public bool canShoot() {
        //return inputHorizontal != 0;
        return true;
    }

    void FixedUpdate()
    {
        /*
        if (inputHorizontal != 0 || inputVertical != 0) // fuer diagonale Bewegung
        {
            // movement speed limitieren
            inputHorizontal = inputHorizontal * speedLimiter;
            inputVertical = inputVertical * speedLimiter;
        }
        
        */
        rb.velocity = new Vector2(inputHorizontal * walkSpeed, inputVertical * walkSpeed); 
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
        /*
        Vector2 lookDir = new Vector2(movement.x, movement.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        */
    }

}

    

