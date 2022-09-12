using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : BulletStruct
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
        Debug.Log("hi");
        if (target_enemy.enemy_type == "type1")
        {
            Hurt = 50f;
        }
        else if(target_enemy.enemy_type == "type4" && upspeed == false && target_enemy.GetComponent<MoveEnemy>().speed < 2.0f)
        {
            Hurt = 30f;
            target_enemy.GetComponent<MoveEnemy>().speed *= 2.0f;
            upspeed = true;
        }
        else
        {
            Hurt = 30f;
        }//對type1敵人傷害提升為50，其他傷害都為20

        damageCalculation();
    }
}
