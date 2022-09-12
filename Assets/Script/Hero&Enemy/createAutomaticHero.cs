using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public class createAutomaticHero : MonoBehaviour
{

    public GameObject Prefab;
    public GameObject[] waypoints;
    int ctr = 0;
    private void OnMouseDown()
    {
        //生成英雄
        GameObject newEnemy = (GameObject)
            Instantiate(Prefab);
        //給予英雄移動路線
        newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
        //調整名字(避免相同名字造成戰鬥bug)
        newEnemy.name = newEnemy.name + ctr;
        ctr++;
    }
}
