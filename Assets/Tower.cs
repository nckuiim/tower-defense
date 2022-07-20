using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Transform target;//射擊目標的位置
    private float fireCountdown = 0f;

    [Header("Attribute")]
    public float range=4f;//射程
    public float fireRate = 1f;//每秒設一發
    

    [Header("unity set up")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
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

        foreach(GameObject enemy in Enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearstEnemy = enemy;
            }
        }//取得當前離防禦塔最近的敵人

        if(nearstEnemy != null && shortestDistance<=range)
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
        GameObject BulletGo=(GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);//將生成的子彈丟給BulletGo
        Bullet bullet = BulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.seek(target);
        }
    }//射擊函數

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }//顯示防禦塔射程
}
