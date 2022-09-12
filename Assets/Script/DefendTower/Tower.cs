using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower : MonoBehaviour
{
    [SerializeField] public bool canAttack; //��O�_�i����
    protected Vector2 offset; //�p��ƹ��M����Z���t�Z
    protected bool enough; //�����O�_�����سy��
    protected TowerManager temp; //�ΨөI�sTowerManager function
    protected HoleManager temp2; //�ΨөI�sHoleManager function
    protected coinCalculation temp3; //�ΨөI�scoinCalculation function
    protected GameObject hole; //tower�n��hole��m

    protected Transform target;//�g���ؼЪ���m
    protected float fireCountdown = 0f;


    [Header("Attribute")]
    public float range;//�g�{
    public float fireRate;//�C��]�@�o
    public bool rotate = false;


    [Header("unity set up")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;//�l�u����
    public Transform firepoint;//�l�u�ͦ��I
    public int num;


    /*public void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        canAttack = false; //�@�}�l������(�𪺼ҪO)���i����
    }*/
    Vector2 getMousePos() //get mouse position function
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    void UpdateTarget()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemyTag);//�Ntag��Enemy�������J�}�C
        float shortestDistance = Mathf.Infinity;//���N�����m�𪺳̵u�Z���]���L�a�j
        GameObject nearstEnemy = null;//�̪񪺼ĤH��null

        foreach (GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }//���o��e�����m��̪񪺼ĤH

        if (nearstEnemy != null && shortestDistance <= range)
        {
            target = nearstEnemy.transform;//���o�ثe�Z���̪񪺼ĤH��m

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

        if (rotate)
        {
            Vector3 v = (target.position - transform.position).normalized;
            transform.right = v;
        }

        if (fireCountdown <= 0f && canAttack)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject BulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);//�N�ͦ����l�u�ᵹBulletGo
        BulletStruct bullet = BulletGo.GetComponent<BulletStruct>();

        if (bullet != null)
        {
            bullet.seek(target);
        }
    }//�g�����

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }//��ܨ��m��g�{



    public void OnMouseDown() //�I���ƹ��ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        temp3 = GameObject.Find("CoinNum").GetComponent<coinCalculation>();
        bool theSame = temp2.checkPos(transform.position);
        int coin = temp3.getCoin(); //�o������ƶq
        float opacity = gameObject.GetComponent<SpriteRenderer>().color.a; //�o���I�����󪺳z����

        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else if (opacity != 1) //�Y�䬰�z�����Nenough �]�� false
        {
            enough = false;
        }
        else
        {
            enough = true;  //�Y�䬰�D�z���Nenough�]��true
            offset = (Vector2)transform.position - getMousePos();

            temp = GetComponentInParent<TowerManager>();

            string name = gameObject.name;
            switch (name)
            {
                case "tower1Base":
                    gameObject.name = "tower1"; //�N�ҪO�M�ظm��������P�W�r
                    temp.spawnTower(1, coin); //�N�ͦ��𪺺����Υثe�����ƶq�ǤJ
                    break;
                case "tower2Base":
                    gameObject.name = "tower2";
                    temp.spawnTower(2, coin);
                    break;
                case "tower3Base":
                    gameObject.name = "tower3";
                    temp.spawnTower(3, coin);
                    break;
                case "tower4Base":
                    gameObject.name = "tower4";
                    temp.spawnTower(4, coin);
                    break;
                default:
                    Debug.Log("tower not exist");
                    break;
            }

            Color co = gameObject.GetComponent<SpriteRenderer>().color;//����L�{�Ϩ��ܳz��
            co.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = co;
        }
    }

    public void OnMouseDrag() //�즲�ƹ��ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);

        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else if (!enough) //�Y���������hdo nothing
        {
        }
        else
        {
            transform.position = getMousePos() + offset; //�����m����
        }
    }

    public void OnMouseUp() //�ƹ���}�ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        temp3 = GameObject.Find("CoinNum").GetComponent<coinCalculation>();
        bool theSame = temp2.checkPos(transform.position);
        int coin = temp3.getCoin();

        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else if (!enough) //�Y���������hdo nothing
        {
        }
        else
        {
            float minDistance; //tower�M�Ҧ�hole���̤p�Z��
            bool place; //�P�_�Ӧ�m�O�_�i��mtower
            temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
            minDistance = temp2.calculateMin(transform.position); //�p��ثetower��m�M�Ҧ�hole���Z��
            place = temp2.whetherPlace(minDistance); //�ھڳ̤p�Z����bool�M�w�O�_�i��m

            if (place == false)
            {
                Destroy(gameObject); //�Y����hdestroy gameobject
            }
            else
            {
                hole = temp2.getHole(); //�Y�i�H���o�̤p�Z����hole����
                transform.position = hole.transform.position; //�Ntower����m�אּhole����m

                Color co = gameObject.GetComponent<SpriteRenderer>().color;//��m������N�z���׽զ^���`
                co.a = 1f;
                gameObject.GetComponent<SpriteRenderer>().color = co;

                coin = modifyCoin(gameObject.name, coin);
                temp3.setCoin(coin);
                canAttack = true;
                //record tower on hole


            }
        }

    }

    public int modifyCoin(string towerName, int currentCoin)
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
        int coin = temp3.getCoin(); //�o������ƶq
        float opacity = gameObject.GetComponent<SpriteRenderer>().color.a; //�o���I�����󪺳z����

        if (theSame) //�Y�b�P��m�hdo nothing
        {
            Destroy(gameObject);

        }



    }
}
