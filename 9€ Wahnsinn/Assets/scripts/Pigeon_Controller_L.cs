using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon_Controller_L : MonoBehaviour
{

    [SerializeField]
    private float speed = 2f; 
    private Rigidbody2D myRigidbody;
    private Vector2 screenBounds;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.velocity = new Vector2(speed, 0);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        if(transform.position.x > screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }
}
