using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower1 : MonoBehaviour
{
    [SerializeField] public bool canAttack; //塔是否可攻擊
    private Vector2 offset; //計算滑鼠和物件距離差距
    private bool enough; //金幣是否足夠建造塔
    TowerManager temp; //用來呼叫TowerManager function
    HoleManager temp2; //用來呼叫HoleManager function
    coinCalculation temp3; //用來呼叫coinCalculation function
    GameObject hole; //tower要放的hole位置

    public void Start()
    {
        canAttack = false; //一開始的物件(塔的模板)不可攻擊
    }
    Vector2 getMousePos() //get mouse position function
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    public void OnMouseDown() //點擊滑鼠時呼叫的function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        temp3 = GameObject.Find("CoinNum").GetComponent<coinCalculation>();
        bool theSame = temp2.checkPos(transform.position); 
        int coin = temp3.getCoin(); //得到金幣數量
        float opacity = gameObject.GetComponent<SpriteRenderer>().color.a; //得到點擊物件的透明度

        if (theSame) //若在同位置則do nothing
        {
        }
        else if(opacity != 1) //若其為透明的將enough 設為 false
        {
            enough = false;
        }
        else
        {
            enough = true;  //若其為非透明將enough設為true
            offset = (Vector2)transform.position - getMousePos();

            temp = GetComponentInParent<TowerManager>();

            string name = gameObject.name;
            switch (name)
            {
                case "tower1Base":
                    gameObject.name = "tower1"; //將模板和建置的塔取不同名字
                    temp.spawnTower(1,coin); //將生成塔的種類及目前金幣數量傳入
                    break;
                case "tower2Base":
                    gameObject.name = "tower2";
                    temp.spawnTower(2,coin);
                    break;
                case "tower3Base":
                    gameObject.name = "tower3";
                    temp.spawnTower(3,coin);
                    break;
                case "tower4Base":
                    gameObject.name = "tower4";
                    temp.spawnTower(4,coin);
                    break;
                default:
                    Debug.Log("tower not exist");
                    break;
            }

            Color co = gameObject.GetComponent<SpriteRenderer>().color;//抓取過程使其變透明
            co.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = co;
        }
    }

    public void OnMouseDrag() //拖曳滑鼠時呼叫的function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);

        if (theSame) //若在同位置則do nothing
        {
        }
        else if (!enough) //若金幣不足則do nothing
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
        temp3 = GameObject.Find("CoinNum").GetComponent<coinCalculation>();
        bool theSame = temp2.checkPos(transform.position);
        int coin = temp3.getCoin();

        if (theSame) //若在同位置則do nothing
        {
        }
        else if (!enough) //若金幣不足則do nothing
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

                coin = modifyCoin(gameObject.name, coin);
                temp3.setCoin(coin);
                canAttack = true;
                //record tower on hole
                

            }
        }

    }

    public int modifyCoin(string towerName , int currentCoin)
    {
        switch (towerName)
        {
            case "tower1":
                currentCoin -= 25;
                break;
            case "tower2":
                currentCoin -= 75;
                break;
            case "tower3":
                currentCoin -= 150;
                break;
            case "tower4":
                currentCoin -= 250;
                break;
            default:
                Debug.Log("tower not exist");
                break;
        }

        return currentCoin;
    }
    public void delete()
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        temp3 = GameObject.Find("CoinNum").GetComponent<coinCalculation>();
        bool theSame = temp2.checkPos(transform.position);
        int coin = temp3.getCoin(); //得到金幣數量
        float opacity = gameObject.GetComponent<SpriteRenderer>().color.a; //得到點擊物件的透明度

        if (theSame) //若在同位置則do nothing
        {
            Destroy(gameObject);

        }
     
        

    }
}
