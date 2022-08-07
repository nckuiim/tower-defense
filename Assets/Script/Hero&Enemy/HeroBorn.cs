using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ªlÀM

public class HeroBorn : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
