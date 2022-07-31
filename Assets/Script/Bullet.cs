using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;//���g�����ؼЦ�m
    public float speed = 70f;//�l�u�t��
    public GameObject impactEffect;//�l�u�����᪺�S��
    private GameObject targetEnemy;
    enemy target_enemy;
    Tower tower_bullet;
    public float Hurt;//�l�u�ˮ`

    
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
        if(target != null)
        {
            targetEnemy = target.gameObject;
            target_enemy = targetEnemy.GetComponent<enemy>();
        }
       
    }

    void HitTarget()
    {
        if (target_enemy.enemy_type == "type1")
        {
            Hurt = 50f;
        }
        else
        {
            Hurt = 30f;
        }//��type1�ĤH�ˮ`���ɬ�50�A��L�ˮ`����20

        GameObject effectIns=(GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//�����ؼЫᲣ�ͯS��
        Destroy(effectIns, 2f);//�S�ĩ�2������
        Destroy(gameObject);//�l�u�����ؼЫ��H�Y����
        target_enemy.HP -= Hurt;//�ĤH����
        Debug.Log("�Ѿl " + target_enemy.HP + " �w��");

        if (target_enemy.HP <= 0)
        {
            Scoreboard.sc += 200;
            RemainEnemy.en -= 1;
            Destroy(target.gameObject);
            return;
        }//�Y�ĤH���`�hdestroy���ĤH����
    }
}
