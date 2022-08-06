using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���O

public class HeroFight : FighterStruct
{
    // Start is called before the first frame update
    void Start() {}

    void Update() 
    {
        //��s�԰����A
        if(!gameObject.GetComponent<HeroFight>().IsInvoking())
        {
            isFight = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //�P�_�O�_�w�g�i�J�԰����A(�קK�^��1���h)
            if (!gameObject.GetComponent<HeroFight>().IsInvoking())
            {
                myAnimator.SetInteger("Status", 0);
                //�s���ĤH����W�r
                colli = collision.gameObject.name;
                //�ϥΧޯ�
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 1, skills[1].getCD());
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //�Y�^�����~���}�A�Ѱ�����԰����A
        if (collision.gameObject == GameObject.Find(colli))
        {
            collision.gameObject.GetComponent<EnemyFight>().CancelInvoke();
            Reset();
        }
    }

    private new void Reset()
    {
        CancelInvoke();
        colli = "None";
        isFight = false;
    }

    void useSkill1()
    {
        //�P�_�ĤH�O�_���`��A�I�s�ĤH�����˨禡
        if (GameObject.Find(colli) == null)
        {
            Reset();
            return;
        }
        //Debug.Log("use skill 1!");
        ATK = skills[0].getAtk();
        GameObject.Find(colli).GetComponent<EnemyFight>().damage(gameObject);
    }

    void useSkill2()
    {
        if (GameObject.Find(colli) == null)
        {
            Reset();
            return;
        }
        //Debug.Log("use skill 2!");
        ATK = skills[1].getAtk();
        GameObject.Find(colli).GetComponent<EnemyFight>().damage(gameObject);
    }

    public void damage()
    {
        if (GameObject.Find(colli).GetComponent<EnemyFight>() != null)
        {
            HP -= GameObject.Find(colli).GetComponent<EnemyFight>().getAtk() - armour;
            Debug.Log("hero health: " + HP.ToString());
            if (HP <= 0)
            {
                Destroy(gameObject);
                CancelInvoke();
                GameObject.Find(colli).GetComponent<EnemyFight>().CancelInvoke();
            }
        }

    }

    private bool isFight = false;

    public bool callFight()
    {
        if (!isFight)
        {
            isFight = true;
            return true;
        }
        return false;
    }

}
