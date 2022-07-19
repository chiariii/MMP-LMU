using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon_Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject pigeonPrefab;

    [SerializeField]
    private float respawnTime  = 20f;

    private Vector2 screenBounds;

   

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(PigeonSpawn());
    }

     void AddPigeon()
    {
        GameObject pigeonInstance = Instantiate(pigeonPrefab) as GameObject;
        float spawnY = Random.Range(1, screenBounds.y);
        pigeonInstance.transform.position = new Vector2(10,spawnY);
    }

    private IEnumerator PigeonSpawn()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            AddPigeon();
        }
    }
}
