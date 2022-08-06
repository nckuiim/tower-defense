using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//秉新
//改動:加入地圖組的拖曳函式

public class Tower : MonoBehaviour
{
    private Vector2 offset; //計算滑鼠和物件距離差距
    TowerManager temp; //用來呼叫TowerManager function
    HoleManager temp2; //用來呼叫HoleManager function
    GameObject hole; //tower要放的hole位置


    private Transform target;//射擊目標的位置
    private float fireCountdown = 0f;

    [Header("Attribute")]
    public float range = 4f;//射程
    public float fireRate = 1f;//每秒設一發


    [Header("unity set up")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;//子彈物件
    public Transform firepoint;//子彈生成點

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemyTag);//將tag為Enemy的物件放入陣列
        float shortestDistance = Mathf.Infinity;//先將離防禦塔的最短距離設為無窮大
        GameObject nearstEnemy = null;//最近的敵人為null

        foreach (GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }//取得當前離防禦塔最近的敵人

        if (nearstEnemy != null && shortestDistance <= range)
        {
            target = nearstEnemy.transform;//取得目前距離最近的敵人位置

        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject BulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);//將生成的子彈丟給BulletGo
        Bullet bullet = BulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.seek(target);
        }
    }//射擊函數

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }//顯示防禦塔射程


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
