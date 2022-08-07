using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�÷s


public class Bullet : MonoBehaviour
{

    private Transform target;//���g�����ؼЦ�m
    private GameObject targetEnemy;
    private EnemyFight target_enemy;

    public float speed = 70f;//�l�u�t��
    public GameObject impactEffect;//�l�u�����᪺�S��
    public float Hurt=10f;//�l�u�ˮ`
    public string enemyType = "type1";//�ĤH����
    public float explosionRadius = 0f;//�z���b�|
    public bool slowBullet = false;//�O�_���w�t��
    public float slowRate = 0.5f;//�w�t�v



    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }//�Y�ĤH���`�h�l�u�۰ʮ���

        Vector3 dir = target.position - transform.position;//�l�u��ؼЪ��Z��
        float distanceThisFrame = speed * Time.deltaTime;//�l�u�����Z��

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }//��l�u�����Z���j��l�u��ؼЪ��Z���N�������ؼ�

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);//���l�u�����y�񥿱`
    

    }

    public void seek(Transform _target)
    {
        target = _target;
       
    }

    void HitTarget()
    {

        GameObject effectIns=(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//�����ؼЫᲣ�ͯS��
        Destroy(effectIns, 2f);//�S�ĩ�2������

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
                
            }//��type1�ĤH�ˮ`���ɬ�50�A��L�ˮ`����20
        }
        else
        {
            Hurt = 10f;
        }
        if (target_enemy != null)
        {
            target_enemy.GetComponent<EnemyFight>().damage(gameObject);//�ĤH����
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
    }//��ܤl�u�z���d��
}
