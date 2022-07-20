using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Transform target;//�g���ؼЪ���m
    private float fireCountdown = 0f;

    [Header("Attribute")]
    public float range=4f;//�g�{
    public float fireRate = 1f;//�C��]�@�o
    

    [Header("unity set up")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
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

        foreach(GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }//���o��e�����m��̪񪺼ĤH

        if(nearstEnemy != null && shortestDistance<=range)
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
        GameObject BulletGo=(GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);//�N�ͦ����l�u�ᵹBulletGo
        Bullet bullet = BulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.seek(target);
        }
    }//�g�����

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }//��ܨ��m��g�{
}
