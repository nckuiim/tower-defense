using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���O

public abstract class EnemyFight : FighterStruct
{
    public string enemy_type = "type1";

    void Start()
    { }

    void Update()
    { }

    //�s���I��������
    private void OnCollisionEnter(Collision collision)
    {
        //�J��^��
        if (collision.gameObject.tag == "Hero")
        {
            //�s���^���W�r
            colli = collision.gameObject.name;
            //�Y�ӭ^�����b�԰����A
            if (!GameObject.Find(colli).GetComponent<HeroFight>().callFight())
            {
                //����
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 2, skills[1].getCD());
            }
        }
        //�J��l�u�I�s�ˮ`�禡
        else if (collision.gameObject.tag == "Bullet")
        {
            damage(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //�Y�^�����~���}�A�Ѱ�����԰����A
        if (collision.gameObject == GameObject.Find(colli))
        {
            collision.gameObject.GetComponent<HeroFight>().CancelInvoke();
            Reset();
        }
    }

    void useSkill1()
    {
        //�P�_�ĤH�O�_���`
        if (GameObject.Find(colli) == null)
        {
            //�����԰����A
            Reset();
            return;
        }
        //�I�s�ĤH�����˨禡
        //Debug.Log("use skill 1!");
        ATK = skills[0].getAtk();
        GameObject.Find(colli).GetComponent<HeroFight>().damage();
    }

    void useSkill2()
    {
        //�P�_�ĤH�O�_���`
        if (GameObject.Find(colli) == null)
        {
            //�����԰����A
            Reset();
            return;
        }
        //�I�s�ĤH�����˨禡
        //Debug.Log("use skill 2!");
        ATK = skills[1].getAtk();
        GameObject.Find(colli).GetComponent<HeroFight>().damage();
    }

    public void damage(GameObject hurt)
    {
        if (hurt.tag == "Hero")
        {
            HP -= hurt.GetComponent<HeroFight>().getAtk() - armour;
            Debug.Log("enemy health: " + HP.ToString());
            if (HP <= 0)
            {
                Destroy(gameObject);
                CancelInvoke();
                hurt.GetComponent<HeroFight>().CancelInvoke();
            }
        }
        else if (hurt.tag == "Bullet")
        {
            HP -= hurt.GetComponent<Bullet>().Hurt - armour;
            Debug.Log("enemy health: " + HP.ToString());
            if (HP <= 0)
            {
                Destroy(gameObject);
                CancelInvoke();
                if(GameObject.Find(colli) != null)
                {
                    GameObject.Find(colli).GetComponent<HeroFight>().CancelInvoke();
                }
            }
        }

    }
    public string Return_type() { return enemy_type; }


}
