using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public Transform target;    // reference to our target

    public Animator animator;
    Vector2 movement;

    public float speed = 200f;    // default speed
    public float nextWayPointDistance = 3f; // how close does an enemy needs to be to a waypoint

    Path path;  // current path that we are following
    int currentWaypoint = 0; // current waypoint we are following along that path
    bool reachedEndOfPath = false; // end of path reached?

    // referencing the other script
    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        // Specify method that repeats 
        InvokeRepeating("UpdatePath", 0f, .5f);     
    }

    void UpdatePath() {
        
        // Check if there is already a path that is being calculated
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete); // Generate a path: starposition = position of our enemy, endposition = targetposition, function we want to call, when it reaches the endpoint
        }
    }
        

    void OnPathComplete(Path p) // generated path as input
    {
        if(!p.error) // if there arent any errors:
        {
            path = p; // setting the newly generated path to the new path
            currentWaypoint = 0; // reset progress along our path to start at the beginning of our new path
        }
    }

    void FixedUpdate()
    {
        if (path == null) // checking if a path was generated
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count) // check if there a more waypoints in the path and not reached the end
        {
            reachedEndOfPath = true;
            return;
        } else 
        { 
            reachedEndOfPath = false;
        }

        // Moving the enemy
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;    // get the direction to the next waypoint along our path
        
        // apply force to enemy so that it moves in this direction
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force); 

        float  distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]); // calculate distance to our next waypoint

        if (distance < nextWayPointDistance)
        {
            currentWaypoint++;
        }

        // Change Animation when changing position
        if (force.x >= 0.01f)
        {
            movement.x = -transform.position.x;
        }
        else if (force.x <= -0.01f)
        {
            movement.x = transform.position.x;
        }
        else if (force.y >= 0.01f)
        {
            movement.y = -transform.position.y;
        }
        else if (force.y <= -0.01f)
        {
            movement.y = transform.position.y;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
}
