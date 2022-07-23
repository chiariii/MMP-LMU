using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSchaffner : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D rbWeapon;
    public Weapon weapon;

    float walkSpeed = 4f;
    float speedLimiter = 0.7f;
    float inputHorizontal;
    float inputVertical;

    Vector2 moveDirection;

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

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown("space")) 
        {
            weapon.Fire();

        }

        moveDirection = new Vector2(moveX, moveY).normalized;

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

    void FixedUpdate()
    {
        
        if (inputHorizontal != 0 || inputVertical != 0) // fuer diagonale Bewegung
        {
            // movement speed limitieren
            inputHorizontal = inputHorizontal * speedLimiter;
            inputVertical = inputVertical * speedLimiter;
        }
        
        
        rb.velocity = new Vector2(moveDirection.x * walkSpeed, moveDirection.y * walkSpeed); 
        //Vector2 aimDirection = rbWeapon.position;
        //float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg -90f;
        //rb.rotation = aimAngle;
        
        //rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
        /*
        
       
        */
    }

}

    

