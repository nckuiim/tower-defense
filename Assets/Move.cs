using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Hero
{
    //public float XSpeed = 1f;
    //public float YSpeed = 1f;
    public static new float HP = 50;
    public static new float ATK = 12;
    public static new float cd = 5;
    //public float armour = 0;

    private new int x = 1;
    private new int y = 0;
    //Skill[] skills = new Skill[3];
    

    // Start is called before the first frame update
    /*void Start()
    {
        skills[0] = new Skill();
        skills[1] = new Skill();
        skills[2] = new Skill();
    }*/

    // Update is called once per frame

    void Update()
    {
        //float moveX = Input.GetAxis("Horizontal") * XSpeed * Time.deltaTime;
        //float moveY = Input.GetAxis("Vertical") * YSpeed * Time.deltaTime;
        float moveX = x * XSpeed * Time.deltaTime;
        float moveY = y * YSpeed * Time.deltaTime;
        Vector2 ans = new Vector2(moveX, moveY);
        transform.Translate(ans);
    }
   
    
    Collision colli = new Collision();
    private void OnCollisionEnter(Collision collision)
    {
        colli = collision;
        if (collision.gameObject.tag == "rightTurn") { right(); }
        else if (collision.gameObject.tag == "leftTurn") { left(); }
        else if (collision.gameObject.tag == "upTurn") { up(); }
        else if (collision.gameObject.tag == "downTurn") { down(); }
        else if (collision.gameObject.tag == "enemy")
        {
            stop();
            //fight();
            colli.gameObject.GetComponent("Enemy").SendMessage("fight");
            InvokeRepeating("damage", 1, Enemy.AtkSpeed);
        }
        else if (collision.gameObject.tag == "exit")
        {
            Destroy(gameObject);
            Debug.Log("hero reaches the goal");
        }
    }
    
    /*void fight()
    {
        InvokeRepeating("Attack", 1, skills[0].cd);
    }*/

   /*void Attack()
    {
        ATK = skills[0].atk;
        colli.gameObject.GetComponent("Enemy").SendMessage("");
    }*/

    void damage()
    {
        HP -= Enemy.Atk - armour;
        Debug.Log("hero health: " + HP.ToString());
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


}
