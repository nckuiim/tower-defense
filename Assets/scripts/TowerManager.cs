using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField] GameObject[] TowerType; //存放各種類的tower 的game object array
    GameObject tower; //紀錄生成的tower
    Vector3[] Pos = new Vector3[15]; //紀錄最底下那排tower的位置的座標array

    void Start() //開始時先將底下座標存入Pos
    {
        for (int i = 0; i < TowerType.Length; i++)
        {
            Pos[i] = TowerType[i].transform.position;
        }
    }

    public void spawnTower(int i)
    {
        tower = Instantiate(TowerType[i - 1], transform); //生成各type of tower
        tower.name = "tower" + i; //改變object name , make it not be cloned

        Color co = tower.GetComponent<SpriteRenderer>().color; //將生成的透明度改為正常
        co.a = 1f;
        tower.GetComponent<SpriteRenderer>().color = co;

        tower.transform.position = Pos[i-1]; //生成的位置為原本底下的位置
        TowerType[i - 1] = tower; //將生成的tower放入存放gmae object的array(prevent destroy finction)
    }

}
