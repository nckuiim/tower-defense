using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//秉新


public class Bullet : MonoBehaviour
{

    private Transform target;//欲射擊的目標位置
    private GameObject targetEnemy;
    private EnemyFight target_enemy;

    public float speed = 70f;//子彈速度
    public GameObject impactEffect;//子彈擊中後的特效
    public float Hurt=10f;//子彈傷害
    public string enemyType = "type1";//敵人種類
    public float explosionRadius = 0f;//爆炸半徑
    public bool slowBullet = false;//是否為緩速塔
    public float slowRate = 0.5f;//緩速率



    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }//若敵人死亡則子彈自動消失

        Vector3 dir = target.position - transform.position;//子彈到目標的距離
        float distanceThisFrame = speed * Time.deltaTime;//子彈走的距離

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }//當子彈走的距離大於子彈到目標的距離代表擊中目標

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);//讓子彈飛的軌跡正常
    

    }

    public void seek(Transform _target)
    {
        target = _target;
       
    }

    void HitTarget()
    {

        GameObject effectIns=(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//擊中目標後產生特效
        Destroy(effectIns, 2f);//特效於2秒後消失

        if(explosionRadius> 0f)
        {
            Explode();
        }

        else if (slowBullet)
        {
            Slow(target);
        }

        else
        {
            Damage(target);
        }

        Destroy(gameObject);//子彈擊中目標後隨即消失
    }

    void Damage(Transform Enemy)
    {
        if (Enemy != null)
        {
            targetEnemy = Enemy.gameObject;
            target_enemy = targetEnemy.GetComponent<EnemyFight>();
        }

        if(explosionRadius == 0f)
        {
            if (target_enemy.Return_type() == enemyType)
            {
                Hurt = 50f;
                
            }
            else
            {
                Hurt = 20f;
                
            }//對type1敵人傷害提升為50，其他傷害都為20
        }
        else
        {
            Hurt = 10f;
        }
        if (target_enemy != null)
        {
            target_enemy.GetComponent<EnemyFight>().damage(gameObject);//敵人扣血
        }

        
        if(target_enemy.getHP() <= 0)
        {
            Destroy(Enemy.gameObject);
            return;
        }
    }

    void Explode()
    {
        
        Collider2D [] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Slow(Transform Enemy)
    {
        Hurt = 5f;

        if (Enemy != null)
        {
            targetEnemy = Enemy.gameObject;
            target_enemy = targetEnemy.GetComponent<EnemyFight>();
        }
        
        if(targetEnemy.GetComponent<MoveEnemy>().speed == targetEnemy.GetComponent<MoveEnemy>().maxSpeed)
        {
            targetEnemy.GetComponent<MoveEnemy>().speed *= slowRate;
        }

        target_enemy.GetComponent<EnemyFight>().damage(gameObject);

        if (target_enemy.getHP() <= 0)
        {
            Destroy(Enemy.gameObject);
            return;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }//顯示子彈爆炸範圍
}
