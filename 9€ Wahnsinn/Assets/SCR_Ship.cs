using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Danndx 2021 (youtube.com/danndx)
From video: youtu.be/u5ieakSbXjA
thanks - delete me! :) */

public class SCR_Ship : MonoBehaviour
{
    public SCR_ShipSpawner ship_spawner;
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
        if(distance > ship_spawner.death_circle_radius)
        {
            RemoveShip();
        }
    }

    void RemoveShip()
    {
        /** Update the total ship count and then destroy this individual ship. **/

        Destroy(gameObject);
        ship_spawner.ship_count -= 1;
    }
}
