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
        }//對type1敵人傷害提升為50，其他傷害都為20
        else 
        {
            Hurt = 20f;
        }

        damageCalculation();
    }
}
