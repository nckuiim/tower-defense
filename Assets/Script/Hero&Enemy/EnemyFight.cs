using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//µú¦O

public abstract class EnemyFight : FighterStruct
{
    public string enemy_type = "type1";
    public float delay_time;
    bool delay = true;
    bool live = false;
    public bool poisonstatus = false;

    void Start()
    { }

    void Update()
    { }

    public void fight(string obj)
    {
        colli = obj;
        InvokeRepeating("useSkill1", 1, skills[0].getCD());
    }

    void useSkill1()
    {
        myAnimator.SetBool("skill1", true);
        ATK = skills[0].getAtk();
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
                Scoreboard.sc += 200;
                RemainEnemy.en--;
                Destroy(gameObject);
                CancelInvoke();
            }
        }
        else if (hurt.tag == "Bullet")
        {
            HP -= hurt.GetComponent<BulletStruct>().Hurt - armour;
            Debug.Log("enemy health: " + HP.ToString());
            if (HP <= 0)
            {
                Scoreboard.sc += 200;
                RemainEnemy.en--;
                Destroy(gameObject);
                CancelInvoke();
                if(GameObject.Find(colli) != null)
                {
                    GameObject.Find(colli).GetComponent<HeroFight>().CancelInvoke();
                }
            }
        }
    }

    public void damage(float damNum)
    {
        HP -= damNum - armour;
        Debug.Log("enemy health: " + HP.ToString());
        if (HP <= 0)
        {
            Scoreboard.sc += 200;
            RemainEnemy.en--;
            Destroy(gameObject);
            CancelInvoke();
            if (GameObject.Find(colli) != null)
            {
                GameObject.Find(colli).GetComponent<HeroFight>().CancelInvoke();
            }
        }
    }
    public string Return_type() { return enemy_type; }


}
