using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower1 : MonoBehaviour
{
    private Vector2 offset; //計算滑鼠和物件距離差距
    TowerManager temp; //用來呼叫TowerManager function
    HoleManager temp2; //用來呼叫HoleManager function
    GameObject hole; //tower要放的hole位置

    Vector2 getMousePos() //get mouse position function
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    public void OnMouseDown() //點擊滑鼠時呼叫的function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);

        if (theSame) //若在同位置則do nothing
        {
        }
        else
        {
            offset = (Vector2)transform.position - getMousePos();

            Color co = gameObject.GetComponent<SpriteRenderer>().color;//改變透明度
            co.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = co;

            temp = GetComponentInParent<TowerManager>();

            string name = gameObject.name;
            switch (name)
            {
                case "tower1":
                    temp.spawnTower(1);
                    break;
                case "tower2":
                    temp.spawnTower(2);
                    break;
                case "tower3":
                    temp.spawnTower(3);
                    break;
                case "tower4":
                    temp.spawnTower(4);
                    break;
                case "tower5":
                    temp.spawnTower(5);
                    break;
                default:
                    Debug.Log("tower not exist");
                    break;
            }
        }
    }

    public void OnMouseDrag() //拖曳滑鼠時呼叫的function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);
        if (theSame) //若在同位置則do nothing
        {
        }
        else
        {
            transform.position = getMousePos() + offset; //物件位置移動
        }
    }

    public void OnMouseUp() //滑鼠放開時呼叫的function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);
        if (theSame) //若在同位置則do nothing
        {
        }
        else
        {
            float minDistance; //tower和所有hole的最小距離
            bool place; //判斷該位置是否可放置tower
            temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
            minDistance = temp2.calculateMin(transform.position); //計算目前tower位置和所有hole的距離
            place = temp2.whetherPlace(minDistance); //根據最小距離及bool決定是否可放置

            if (place == false)
            {
                Destroy(gameObject); //若不行則destroy gameobject
            }
            else
            {
                hole = temp2.getHole(); //若可以取得最小距離的hole物件
                transform.position = hole.transform.position; //將tower的位置改為hole的位置

                Color co = gameObject.GetComponent<SpriteRenderer>().color;//放置完成後將透明度調回正常
                co.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = co;
            }
        }
       
    }

}
