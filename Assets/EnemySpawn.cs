using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject EnemyPrefab;
    public GameObject EnemyPrefab_2;

    public int numberofenemy = 50/2;
    public float levleWidth = 3f;
    public float minX = .5f;
    public float maxX = 3.5f;


    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberofenemy; i++)
        {
            spawnPosition.x += Random.Range(minX, maxX);
            //ne egyvonalba spawnoljanak
           //spawnPosition.y = Random.Range(-levleWidth, levleWidth);
            Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            spawnPosition.x += Random.Range(minX, maxX);
            Instantiate(EnemyPrefab_2, spawnPosition, Quaternion.identity);
        } 
    }
}
