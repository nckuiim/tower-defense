using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet6 : BulletStruct
{
    public GameObject impactEffect2;
    public GameObject detect;

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
        //對type1敵人傷害提升為50，其他傷害都為20

        GameObject effectIns2 = (GameObject)Instantiate(impactEffect2, new Vector3(Mathf.Round(transform.position.x) - 7.83f, Mathf.Round(transform.position.y) - 0.3f, 0), transform.rotation);
        GameObject detection = (GameObject)Instantiate(detect, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        Destroy(effectIns2, 5f);
        Destroy(detection, 5f);

        damageCalculation();
    }

    void poista()
    {
        if (target_enemy.poisonstatus == true)
        {
            Hurt = 100f;
        }
        else
        {
            Hurt = 70f;
        }
    }

}
