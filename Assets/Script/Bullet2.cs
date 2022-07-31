using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

    private Transform target;//欲射擊的目標位置
    public float speed = 70f;//子彈速度
    public GameObject impactEffect;//子彈擊中後的特效
    private GameObject targetEnemy;
    enemy target_enemy;
    public float Hurt;//子彈傷害


    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }//若敵人死亡則子彈自動消失

        Vector3 dir = target.position - transform.position;//子彈到目標的距離
        float distanceThisFrame = speed * Time.deltaTime;//子彈走的距離

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }//當子彈走的距離大於子彈到目標的距離代表擊中目標

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);//讓子彈飛的軌跡正常

    }

    public void seek(Transform _target)
    {
        target = _target;
        if (target != null)
        {
            targetEnemy = target.gameObject;
            target_enemy = targetEnemy.GetComponent<enemy>();
        }

    }

    void HitTarget()
    {
        if (target_enemy.enemy_type == "type1" || target_enemy.enemy_type == "type2")
        {
            Hurt = 20f;
            target_enemy.x_speed *= 0.5f;
            target_enemy.y_speed *= 0.5f;
        }
        else
        {
            Hurt = 20;
        }//對type1敵人傷害提升為50，其他傷害都為20

        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//擊中目標後產生特效
        Destroy(effectIns, 2f);//特效於2秒後消失
        Destroy(gameObject);//子彈擊中目標後隨即消失
        
        
        target_enemy.HP -= Hurt;//敵人扣血
        Debug.Log("剩餘 " + target_enemy.HP + " 滴血");

        if (target_enemy.HP <= 0)
        {
            Scoreboard.sc += 200;
            RemainEnemy.en -= 1;
            Destroy(target.gameObject);
            return;
        }//若敵人死亡則destroy掉敵人物件
    }
}
