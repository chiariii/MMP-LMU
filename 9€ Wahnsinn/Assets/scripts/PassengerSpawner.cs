using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject PassengerPrefab1;

    [SerializeField]
    private GameObject PassengerPrefab2;

    [SerializeField]
    private GameObject PassengerPrefab3;

    [SerializeField]
    private GameObject PassengerPrefab4;

    [SerializeField]
    private GameObject PassengerPrefab5;

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

        GameObject[] passengers = {PassengerPrefab1, PassengerPrefab2, PassengerPrefab3, PassengerPrefab4, PassengerPrefab5};
        int randomPassenger = Random.Range(0, passengers.Length);

        GameObject passengersInstance = Instantiate(passengers[randomPassenger]) as GameObject;
        
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
