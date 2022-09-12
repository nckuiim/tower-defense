using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletStruct
{
    private void Start()
    {
        speed = 70f;//�l�u�t��
        Hurt = 10f;//�l�u�ˮ`
        enemyType = "type1";//�ĤH����
        explosionRadius = 0f;//�z���b�|
        slowBullet = false;//�O�_���w�t��
        slowRate = 0.5f;//�w�t�v
    }

    void Update()
    {
        bulletMove();
    }

    public override void HitTarget()
    {

        //GameObject effectIns=(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//�����ؼЫᲣ�ͯS��
        //Destroy(effectIns, 2f);//�S�ĩ�2������

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

        Destroy(gameObject);//�l�u�����ؼЫ��H�Y����
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
                
            }//��type1�ĤH�ˮ`���ɬ�50�A��L�ˮ`����20
        }
        else
        {
            Hurt = 10f;
        }
        damageCalculation();
        /*if (target_enemy != null)
        {
            target_enemy.GetComponent<EnemyFight>().damage(gameObject);//�ĤH����
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
    }//��ܤl�u�z���d��
}
