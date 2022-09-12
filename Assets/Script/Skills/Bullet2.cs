using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : BulletStruct
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
        if (target_enemy.enemy_type == "type1" || target_enemy.enemy_type == "type2")
        {
            Hurt = 20f;
            target_enemy.GetComponent<MoveEnemy>().speed *= 0.5f;
        }
        else if (target_enemy.enemy_type == "type4" && upspeed == false && target_enemy.GetComponent<MoveEnemy>().speed < 2.0f)
        {
            Hurt = 20f;
            target_enemy.GetComponent<MoveEnemy>().speed *= 2.0f;
            upspeed = true;
        }//��type1�ĤH�ˮ`���ɬ�50�A��L�ˮ`����20
        else 
        {
            Hurt = 20f;
        }

        damageCalculation();
    }
}
