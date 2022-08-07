using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public class Hero : HeroFight
{
    //設置英雄的數值
    void Start()
    {
        maxHP = 80;
        HP = 80;
        oriAtk = 12;
        ATK = 12;
        cd = 5;
        armour = 0;
        skills = new Skill[2];
        skills[0] = new Skill1();
        skills[1] = new Skill2();
        myAnimator = gameObject.transform.Find("Sprite").GetComponent<Animator>();
        mySpriteRenderer = gameObject.transform.Find("Sprite").GetComponent<SpriteRenderer>();
        myAnimator.SetInteger("Status", status);
    }
}
