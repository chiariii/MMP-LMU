using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSchaffner : MonoBehaviour
{

    Rigidbody2D rb;

    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizonatal;
    float inputVertical;

    private Animator anim;


    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizonatal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if(inputVertical < 0 && inputHorizonatal == 0)
        {
            anim.SetBool("IsSouth", true);
            anim.SetBool("IsNorth", false);
            anim.SetBool("IsEast", false);
            anim.SetBool("IsWest", false);
        }
        else if(inputVertical > 0 && inputHorizonatal == 0)
        {
            anim.SetBool("IsSouth", false);
            anim.SetBool("IsNorth", true);
            anim.SetBool("IsEast", false);
            anim.SetBool("IsWest", false);
        }
        else if(inputHorizonatal < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);	
            anim.SetBool("IsSouth", false);
            anim.SetBool("IsNorth", false);
            anim.SetBool("IsEast", true);
            anim.SetBool("IsWest", false);
        }
        else if(inputHorizonatal > 0)
        {
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

    void FixedUpdate()
    {
        if (inputHorizonatal != 0 || inputVertical != 0) // fuer diagonale Bewegung
        {
            // movement speed limitieren
            inputHorizonatal = inputHorizonatal * speedLimiter;
            inputVertical = inputVertical * speedLimiter;
        }
        rb.velocity = new Vector2(inputHorizonatal * walkSpeed, inputVertical * walkSpeed); 
    }

}

    

