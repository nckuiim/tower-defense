using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet5 : BulletStruct
{

    private void Start()
    {
        speed = 70f;
        upspeed = false;
    }


    void Update()
    {
        bulletMove();
    }

    public override void HitTarget()
    {
        if (target_enemy.enemy_type == "type4" && upspeed == false && target_enemy.GetComponent<MoveEnemy>().speed < 2.0f)
        {
            target_enemy.GetComponent<MoveEnemy>().speed *= 2.0f;
            poista();
            upspeed = true;
        }
        else 
        {
            poista();
        }
        damageCalculation();
    }

    void poista()
    {
        if(target_enemy.poisonstatus == true)
        {
            Hurt = 100f;
        }
        else
        {
            Hurt = 70f;
        }
    }

}
