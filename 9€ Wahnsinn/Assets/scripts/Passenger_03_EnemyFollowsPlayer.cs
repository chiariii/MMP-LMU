using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger_03_EnemyFollowsPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSight = 10f;
    public Animator animator;
    private Transform player;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSight) 
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            movement.x = -transform.position.x;
            movement.y = transform.position.y;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // For testing purposes only: Making the Sphere visible
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
    }


}
