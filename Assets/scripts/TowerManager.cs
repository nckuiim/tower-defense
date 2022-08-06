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

    public void spawnTower(int i , int coin)
    {
        tower = Instantiate(TowerType[i - 1], transform); //生成各type of tower
        tower.name = "tower" + i + "Base"; //改變object name , make it not be cloned
        Color co = tower.GetComponent<SpriteRenderer>().color;
        switch (i) //生成塔模板的透明度，若金幣足夠則非透明，不足夠則透明
        {
            case 1:
                if(coin >= 25)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            case 2:
                if (coin >= 75)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            case 3:
                if (coin >= 150)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            case 4:
                if (coin >= 250)
                {
                    co.a = 1f;
                }
                else
                {
                    co.a = 0.4f;
                }
                break;
            default:
                break;
        }

        tower.GetComponent<SpriteRenderer>().color = co; //將透明度設為透明或非透明

        tower.transform.position = Pos[i-1]; //生成的位置為原本底下的位置
        TowerType[i - 1] = tower; //將生成的tower放入存放gmae object的array(prevent destroy finction)
    }

}
