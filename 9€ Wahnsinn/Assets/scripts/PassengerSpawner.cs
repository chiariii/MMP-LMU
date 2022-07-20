using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PassengerPrefab1;

    [SerializeField]
    private float respawnTime  = 5f;

    private Vector2 screenBounds;

   

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(PassengerSpawn());
    }

     void AddPassenger()
    {

        GameObject passengersInstance = Instantiate(PassengerPrefab1) as GameObject;
        float spawnX = Random.Range(-7, 7);
        passengersInstance.transform.position = new Vector2(spawnX, -screenBounds.y - 3);
    }

    private IEnumerator PassengerSpawn()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            AddPassenger();
        }
    }
}
