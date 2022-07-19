using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Hero
{
    public float moveSpeed = 1f;
    public static float HP = 50;
    public static float ATK = 12;
    public static float cd = 5;
    public float armour = 0;

    private int x = 1;
    private int y = 0;
    Skill[] skills = new Skill[3];
    

    // Start is called before the first frame update
    void Start()
    {
        skills[0] = new Skill1();
        skills[1] = new Skill2();
        //skills[2] = new Skill();
    }

    // Update is called once per frame

    void Update()
    {
        if (!gameObject.GetComponent<Hero>().IsInvoking() && isStop())
        {
            x = 1;
        }
        float moveX = x * moveSpeed * Time.deltaTime;
        float moveY = y * moveSpeed * Time.deltaTime;
        Vector2 ans = new Vector2(moveX, moveY);
        transform.Translate(ans);
    }
   
    bool isStop()
    {
        return (x == 0 && y == 0);
    }
    
    string colli;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "rightTurn") { right(); }
        else if (collision.gameObject.tag == "leftTurn") { left(); }
        else if (collision.gameObject.tag == "upTurn") { up(); }
        else if (collision.gameObject.tag == "downTurn") { down(); }
        else if (collision.gameObject.tag == "enemy")
        {
            stop();
            colli = collision.gameObject.name;
            InvokeRepeating("useSkill1", 1, skills[0].getCD());
            InvokeRepeating("useSkill2", 2, skills[1].getCD());
        }
        else if (collision.gameObject.tag == "exit")
        {
            Destroy(gameObject);
            Debug.Log("hero reaches the goal");
        }
    }

    void hello()
    {
        Debug.Log("hello");
    }

    void useSkill1()
    {
        if (GameObject.Find(colli).GetComponent<Enemy>().getHP() > 0)
        {
            Debug.Log("use skill 1!");
            ATK = skills[0].getAtk();
            GameObject.Find(colli).GetComponent<Enemy>().minus(skills[0].getAtk(), skills[0].getAtkType());
        }
    }

    void useSkill2()
    {
        if (GameObject.Find(colli).GetComponent<Enemy>().getHP() > 0)
        {
            Debug.Log("use skill 2!");
            ATK = skills[1].getAtk();
            GameObject.Find(colli).GetComponent<Enemy>().minus(skills[1].getAtk(), skills[1].getAtkType());
        }
    }
    new void damage()
    {
        HP -= Enemy.Atk - armour;
        //Debug.Log("hero health: " + HP.ToString());
        if(HP <= 0)
        {
            Destroy(gameObject);
            CancelInvoke();
        }
        if(Enemy.HP <= 0)
        {
            CancelInvoke();
        }
    }
    new void right() { x = 1; y = 0; }

    new void left() { x = -1; y = 0; }

    new void up() { x = 0; y = 1; }

    new void down() { x = 0; y = -1; }

    new void stop() { x = 0; y = 0; }

    public override float getMoveSpd()
    {
        return moveSpeed;
    }

    public override float getHP()
    {
        return HP;
    }

    public override float getAtk()
    {
        return ATK;
    }

    public override float getCD()
    {
        return cd;
    }

    public override float getArmour()
    {
        return armour;
    }
}
