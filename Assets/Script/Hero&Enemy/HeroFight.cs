using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public class HeroFight : FighterStruct
{
    // Start is called before the first frame update
    void Start() {}

    void Update() 
    {}

    public bool skill1act = true;
    public bool skill2act = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //判斷是否已經有戰鬥對象(避免英雄1打多)
            if (colli == "None")
            {
                //英雄敵人停止移動
                collision.gameObject.GetComponent<MoveEnemy>().stopFighter();
                if (GetComponent<MoveEnemy>() != null)
                {
                    GetComponent<MoveEnemy>().stopFighter();
                }
                myAnimator.SetInteger("Status", 0);
                //存取敵人物件名字
                colli = collision.gameObject.name;
                collision.gameObject.GetComponent<EnemyFight>().fight(name);
                //使用技能
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 2, skills[1].getCD());

            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //若英雄中途離開，解除雙方戰鬥狀態
        if (collision.gameObject.name == colli)
        {
            collision.gameObject.GetComponent<EnemyFight>().CancelInvoke();
            collision.gameObject.GetComponent<MoveEnemy>().moveFighter();
            if (GetComponent<MoveEnemy>() != null)
            {
                GetComponent<MoveEnemy>().moveFighter();
            }
            Reset();
        }
    }

    private new void Reset()
    {
        CancelInvoke();
        colli = "None";
    }

    void useSkill1()
    {
        myAnimator.SetBool("skill1", true);
        //判斷敵人是否死亡後，呼叫敵人的受傷函式
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

    void useSkill2()
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
