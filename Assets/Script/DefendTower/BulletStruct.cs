using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletStruct : MonoBehaviour
{
    protected Transform target;//���g�����ؼЦ�m
    protected GameObject targetEnemy;
    protected EnemyFight target_enemy;

    public float speed;//�l�u�t��
    public GameObject impactEffect;//�l�u�����᪺�S��
    public float Hurt;//�l�u�ˮ`
    public string enemyType;//�ĤH����
    public float explosionRadius;//�z���b�|
    public bool slowBullet = false;//�O�_���w�t��
    public float slowRate;//�w�t�v

    protected Tower tower_bullet;
    protected bool upspeed = false;


    protected void bulletMove()
    {
        if (target == null)
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
        Debug.Log("seek");
        target = _target;
        if (target != null)
        {
            targetEnemy = target.gameObject;
            target_enemy = targetEnemy.GetComponent<EnemyFight>();
        }

    }

    protected void damageCalculation()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//�����ؼЫᲣ�ͯS��
        Destroy(effectIns, 2f);//�S�ĩ�2������
        Destroy(gameObject);//�l�u�����ؼЫ��H�Y����
        target_enemy.damage(gameObject);//�ĤH����
        Debug.Log("�Ѿl " + target_enemy.getHP() + " �w��");

        if (target_enemy.getHP() <= 0)
        {
            Scoreboard.sc += 200;
            RemainEnemy.en -= 1;
            Destroy(target.gameObject);
            return;
        }//�Y�ĤH���`�hdestroy���ĤH����
    }

    public abstract void HitTarget();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }//��ܤl�u�z���d��
}
