using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�÷s
//���:�[�J�a�ϲժ��즲�禡

public class Tower : MonoBehaviour
{
    private Vector2 offset; //�p��ƹ��M����Z���t�Z
    TowerManager temp; //�ΨөI�sTowerManager function
    HoleManager temp2; //�ΨөI�sHoleManager function
    GameObject hole; //tower�n��hole��m


    private Transform target;//�g���ؼЪ���m
    private float fireCountdown = 0f;

    [Header("Attribute")]
    public float range = 4f;//�g�{
    public float fireRate = 1f;//�C��]�@�o


    [Header("unity set up")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;//�l�u����
    public Transform firepoint;//�l�u�ͦ��I

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject BulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);//�N�ͦ����l�u�ᵹBulletGo
        Bullet bullet = BulletGo.GetComponent<Bullet>();

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


    Vector2 getMousePos() //get mouse position function
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    public void OnMouseDown() //�I���ƹ��ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);

        if (theSame) //�Y�b�P��m�hdo nothing
        {
        }
        else
        {
            offset = (Vector2)transform.position - getMousePos();

            Color co = gameObject.GetComponent<SpriteRenderer>().color;//���ܳz����
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

    public void OnMouseDrag() //�즲�ƹ��ɩI�s��function
    {
        temp2 = GameObject.Find("HoleManager").GetComponent<HoleManager>();
        bool theSame = temp2.checkPos(transform.position);
        if (theSame) //�Y�b�P��m�hdo nothing
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
        bool theSame = temp2.checkPos(transform.position);
        if (theSame) //�Y�b�P��m�hdo nothing
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
            }
        }
       
    }

}
