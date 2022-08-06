using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public class HeroFight : FighterStruct
{
    // Start is called before the first frame update
    void Start() {}

    void Update() 
    {
        //更新戰鬥狀態
        if(!gameObject.GetComponent<HeroFight>().IsInvoking())
        {
            isFight = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //判斷是否已經進入戰鬥狀態(避免英雄1打多)
            if (!gameObject.GetComponent<HeroFight>().IsInvoking())
            {
                myAnimator.SetInteger("Status", 0);
                //存取敵人物件名字
                colli = collision.gameObject.name;
                //使用技能
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 1, skills[1].getCD());
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //若英雄中途離開，解除雙方戰鬥狀態
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
        //判斷敵人是否死亡後，呼叫敵人的受傷函式
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
