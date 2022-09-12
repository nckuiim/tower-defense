using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4 : BulletStruct
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
        Hurt = 30f;
        if (target_enemy.enemy_type == "type4" && upspeed == false && target_enemy.GetComponent<MoveEnemy>().speed < 2.0f)
        {
            target_enemy.GetComponent<MoveEnemy>().speed *= 2.0f;
            upspeed = true;
        }
        Invoke("PoisonDamage", 0f);
        //對type1敵人傷害提升為50，其他傷害都為20

        damageCalculation();
    }

    public void PoisonDamage()
    {
        target_enemy.poisonstatus = true;
        target_enemy.damage(5f);
        Debug.Log("中毒 剩 " + target_enemy.getHP() + "滴血");
        target_enemy.damage(5f);
        Debug.Log("中毒 剩 " + target_enemy.getHP() + "滴血");
        target_enemy.damage(5f);
        Debug.Log("中毒 剩 " + target_enemy.getHP() + "滴血");
    }
}
