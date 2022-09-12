using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���O

public class HeroFight : FighterStruct
{
    // Start is called before the first frame update
    void Start() {}

    void Update() 
    {}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //�P�_�O�_�w�g���԰���H(�קK�^��1���h)
            if (colli == "None")
            {
                //�^���ĤH�����
                collision.gameObject.GetComponent<MoveEnemy>().stopFighter();
                if (GetComponent<MoveEnemy>() != null)
                {
                    GetComponent<MoveEnemy>().stopFighter();
                }
                myAnimator.SetInteger("Status", 0);
                //�s���ĤH����W�r
                colli = collision.gameObject.name;
                collision.gameObject.GetComponent<EnemyFight>().fight(name);
                //�ϥΧޯ�
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                //InvokeRepeating("useSkill2", 2, skills[1].getCD());

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //�Y�^�����~���}�A�Ѱ�����԰����A
        if (collision.gameObject.name == colli)
        {
            collision.gameObject.GetComponent<EnemyFight>().CancelInvoke();
            collision.gameObject.GetComponent<MoveEnemy>().moveFighter();
            Reset();
        }
    }

    public new void Reset()
    {
        myAnimator.SetInteger("Status", 1);
        CancelInvoke();
        colli = "None";
        if (GetComponent<MoveEnemy>() != null)
        {
            GetComponent<MoveEnemy>().moveFighter();
        }
    }

    void useSkill1()
    {
        myAnimator.SetBool("skill1", true);
        //�P�_�ĤH�O�_���`��A�I�s�ĤH�����˨禡
        if (GameObject.Find(colli) == null)
        {
            Reset();
            return;
        }
        Debug.Log("use skill 1!");
        ATK = skills[0].getAtk();
        GameObject.Find(colli).GetComponent<EnemyFight>().damage(gameObject);
        //myAnimator.SetBool("skill1", false);
    }

    /*void useSkill2()
    {
        myAnimator.SetBool("skill2", true);
        if (GameObject.Find(colli) == null)
        {
            Reset();
            return;
        }
        Debug.Log("use skill 2!");
        ATK = skills[1].getAtk();
        GameObject.Find(colli).GetComponent<EnemyFight>().damage(gameObject);
        //myAnimator.SetBool("skill1", false);
    }*/

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
                GameObject.Find(colli).GetComponent<MoveEnemy>().moveFighter();
            }
        }

    }

    public bool callFight(string obj)
    {
        if (obj == colli)
        {
            return true;
        }
        return false;
    }

}
