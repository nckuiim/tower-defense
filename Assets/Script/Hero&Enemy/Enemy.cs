using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//詠吏

public class Enemy : EnemyFight
{
    //設置敵人的數值
    void Start()
    {
        maxHP = 100;
        HP = 100;
        oriAtk = 12;
        ATK = 12;
        cd = 5;
        armour = 0;
        enemy_type = "type1";
        skills = new Skill[2];
        skills[0] = new Skill1();
        skills[1] = new Skill2();
    }
}
