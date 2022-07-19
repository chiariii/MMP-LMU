using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigeon_Spawner_R : MonoBehaviour
{

    [SerializeField]
    private GameObject pigeonPrefab1;

    [SerializeField]
    private GameObject pigeonPrefab2;


    [SerializeField]
    private float respawnTime  = 5f;

    private Vector2 screenBounds;

   

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(PigeonSpawn());
    }

     void AddPigeon()
    {
        GameObject[] pigeons = {pigeonPrefab1, pigeonPrefab2};
        int index = Random.Range(0, pigeons.Length);

        GameObject pigeonInstance = Instantiate(pigeons[index]) as GameObject;
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
