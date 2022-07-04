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


    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizonatal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (inputHorizonatal != 0 || inputVertical != 0)
        {
                rb.velocity = new Vector2(inputHorizonatal * walkSpeed, inputVertical * walkSpeed); 
        }
        
    }

}

    

