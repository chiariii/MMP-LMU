using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    public Pigeon_Spawner pigeon_spawner;
    public GameObject game_area;

    public float speed;

    void Update()
    {
        Move();
    }

    void Move()
    {
        /** Move this ship forward per frame, if it gets too far from the game area, destroy it **/

        transform.position += transform.up * (Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, game_area.transform.position);
        if(distance > pigeon_spawner.death_circle_radius)
        {
            RemoveShip();
        }
    }

    void RemoveShip()
    {
        /** Update the total ship count and then destroy this individual ship. **/

        Destroy(gameObject);
        pigeon_spawner.pigeon_count -= 1;
    }
}
