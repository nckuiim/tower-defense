using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletStruct
{
    private void Start()
    {
        speed = 70f;//子彈速度
        Hurt = 10f;//子彈傷害
        enemyType = "type1";//敵人種類
        explosionRadius = 0f;//爆炸半徑
        slowBullet = false;//是否為緩速塔
        slowRate = 0.5f;//緩速率
    }

    void Update()
    {
        bulletMove();
    }

    public override void HitTarget()
    {

        //GameObject effectIns=(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//擊中目標後產生特效
        //Destroy(effectIns, 2f);//特效於2秒後消失

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
        /*if (Enemy != null)
        {
            targetEnemy = Enemy.gameObject;
            target_enemy = targetEnemy.GetComponent<EnemyFight>();
        }*/

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
        damageCalculation();
        /*if (target_enemy != null)
        {
            target_enemy.GetComponent<EnemyFight>().damage(gameObject);//敵人扣血
        }

        
        if(target_enemy.getHP() <= 0)
        {
            Scoreboard.sc += 200;
            Destroy(Enemy.gameObject);
            return;
        }*/
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
