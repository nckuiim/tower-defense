using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{

    private Transform target;//���g�����ؼЦ�m
    public float speed = 70f;//�l�u�t��
    public GameObject impactEffect;//�l�u�����᪺�S��
    private GameObject targetEnemy;
    EnemyFight target_enemy;
    public float Hurt;//�l�u�ˮ`


    void Update()
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
        target = _target;
        if (target != null)
        {
            targetEnemy = target.gameObject;
            target_enemy = targetEnemy.GetComponent<EnemyFight>();
        }

    }

    void HitTarget()
    {

        Hurt = 50f * Mathf.Abs(Mathf.Pow((target.position.x - transform.position.x)*(target.position.x - transform.position.x)+(target.position.y - transform.position.y)*(target.position.y - transform.position.y), 0.5f));

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//�����ؼЫᲣ�ͯS��
        Destroy(effectIns, 2f);//�S�ĩ�2������
        Destroy(gameObject);//�l�u�����ؼЫ��H�Y����


        target_enemy.GetComponent<EnemyFight>().damage(gameObject);//�ĤH����
        Debug.Log("�Ѿl " + target_enemy.getHP() + " �w��");

        if (target_enemy.getHP() <= 0)
        {
            Scoreboard.sc += 200;
            RemainEnemy.en -= 1;
            Destroy(target.gameObject);
            return;
        }//�Y�ĤH���`�hdestroy���ĤH����
    }

}
