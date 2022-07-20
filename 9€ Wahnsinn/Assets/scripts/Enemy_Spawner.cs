using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab;

    [SerializeField]
    private float respawnTime  = 5f;

    private Vector2 screenBounds;
                                                                              

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        StartCoroutine(EnemySpawn());
    }

     void AddEnemy()
    {
        GameObject passengersInstance = Instantiate(EnemyPrefab) as GameObject;

        float spawnY = Random.Range(-screenBounds.y - 3, 0);
        passengersInstance.transform.position = new Vector2(-screenBounds.x, spawnY);
    }

    private IEnumerator EnemySpawn()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            AddEnemy();
        }
    }
}
