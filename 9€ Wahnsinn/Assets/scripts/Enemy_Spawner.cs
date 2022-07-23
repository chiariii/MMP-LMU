
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyPrefab1;

    [SerializeField]
    private GameObject EnemyPrefab2;

    [SerializeField]
    private GameObject EnemyPrefab3;

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

        GameObject[] enemies = {EnemyPrefab1, EnemyPrefab2, EnemyPrefab3};
        int randomEnemy = Random.Range(0, enemies.Length);

        GameObject passengersInstance = Instantiate(enemies[randomEnemy]) as GameObject;

        float[] positions = {-2.0f, -4.0f};
        int index = Random.Range(0, positions.Length);

        float[] positions1 = {-10.0f, 10.0f};
        int index1 = Random.Range(0, positions.Length);

        passengersInstance.transform.position = new Vector2(positions1[index1], positions[index]);
    }

    private IEnumerator EnemySpawn()
    {
        while(true){
            yield return new WaitForSeconds(respawnTime);
            AddEnemy();
        }
    }
}
