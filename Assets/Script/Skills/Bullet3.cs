using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : BulletStruct
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

        Hurt = 50f * Mathf.Abs(Mathf.Pow((target.position.x - transform.position.x)*(target.position.x - transform.position.x)+(target.position.y - transform.position.y)*(target.position.y - transform.position.y), 0.5f));

        if(target_enemy.enemy_type == "type4" && upspeed == false && target_enemy.GetComponent<MoveEnemy>().speed < 2.0f)
        {
            target_enemy.GetComponent<MoveEnemy>().speed *= 2.0f;

            upspeed = true;
        }
        damageCalculation();
    }

}
