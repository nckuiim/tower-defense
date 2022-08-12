using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;


    void Start()
    {
        Instantiate(testEnemyPrefab).GetComponent<EnemyMove>().waypoints = waypoints;
    }

    void Update()
    {

    }

    void Enemyproduce()
    {

        Thread.Sleep(1000);
    }
}
