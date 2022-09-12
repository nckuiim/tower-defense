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
        //��type1�ĤH�ˮ`���ɬ�50�A��L�ˮ`����20

        damageCalculation();
    }

    public void PoisonDamage()
    {
        target_enemy.poisonstatus = true;
        target_enemy.damage(5f);
        Debug.Log("���r �� " + target_enemy.getHP() + "�w��");
        target_enemy.damage(5f);
        Debug.Log("���r �� " + target_enemy.getHP() + "�w��");
        target_enemy.damage(5f);
        Debug.Log("���r �� " + target_enemy.getHP() + "�w��");
    }
}
