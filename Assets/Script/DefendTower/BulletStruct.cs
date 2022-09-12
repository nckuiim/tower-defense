using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletStruct : MonoBehaviour
{
    protected Transform target;//欲射擊的目標位置
    protected GameObject targetEnemy;
    protected EnemyFight target_enemy;

    public float speed;//子彈速度
    public GameObject impactEffect;//子彈擊中後的特效
    public float Hurt;//子彈傷害
    public string enemyType;//敵人種類
    public float explosionRadius;//爆炸半徑
    public bool slowBullet = false;//是否為緩速塔
    public float slowRate;//緩速率

    protected Tower tower_bullet;
    protected bool upspeed = false;


    protected void bulletMove()
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
        Debug.Log("seek");
        target = _target;
        if (target != null)
        {
            targetEnemy = target.gameObject;
            target_enemy = targetEnemy.GetComponent<EnemyFight>();
        }

    }

    protected void damageCalculation()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);//擊中目標後產生特效
        Destroy(effectIns, 2f);//特效於2秒後消失
        Destroy(gameObject);//子彈擊中目標後隨即消失
        target_enemy.damage(gameObject);//敵人扣血
        Debug.Log("剩餘 " + target_enemy.getHP() + " 滴血");

        if (target_enemy.getHP() <= 0)
        {
            Scoreboard.sc += 200;
            RemainEnemy.en -= 1;
            Destroy(target.gameObject);
            return;
        }//若敵人死亡則destroy掉敵人物件
    }

    public abstract void HitTarget();

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }//顯示子彈爆炸範圍
}
