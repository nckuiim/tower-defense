using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public abstract class EnemyFight : FighterStruct
{
    public string enemy_type = "type1";

    void Start()
    { }

    void Update()
    { }

    //存取碰撞的物件
    private void OnCollisionEnter(Collision collision)
    {
        //遇到英雄
        if (collision.gameObject.tag == "Hero")
        {
            //存取英雄名字
            colli = collision.gameObject.name;
            //若該英雄不在戰鬥狀態
            if (!GameObject.Find(colli).GetComponent<HeroFight>().callFight())
            {
                //攻擊
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 2, skills[1].getCD());
            }
        }
        //遇到子彈呼叫傷害函式
        else if (collision.gameObject.tag == "Bullet")
        {
            damage(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //若英雄中途離開，解除雙方戰鬥狀態
        if (collision.gameObject == GameObject.Find(colli))
        {
            collision.gameObject.GetComponent<HeroFight>().CancelInvoke();
            Reset();
        }
    }

    void useSkill1()
    {
        //判斷敵人是否死亡
        if (GameObject.Find(colli) == null)
        {
            //取消戰鬥狀態
            Reset();
            return;
        }
        //呼叫敵人的受傷函式
        //Debug.Log("use skill 1!");
        ATK = skills[0].getAtk();
        GameObject.Find(colli).GetComponent<HeroFight>().damage();
    }

    void useSkill2()
    {
        //判斷敵人是否死亡
        if (GameObject.Find(colli) == null)
        {
            //取消戰鬥狀態
            Reset();
            return;
        }
        //呼叫敵人的受傷函式
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
