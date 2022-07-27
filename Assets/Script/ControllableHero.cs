using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableHero : Hero
{
    private float moveSpeed = 1f;
    private float HP = 100;
    private float ATK = 12;
    private float cd = 5;
    private float armour = 0;
    Skill[] skills = new Skill[2];

    // 安裝技能
    void Start()
    {
        skills[0] = new Skill1();
        skills[1] = new Skill2();
    }

    private float xPos;
    private float yPos;
    private float zPos = 0;
    private Vector3 screenPoint;
    private Vector3 offset;

    //移動英雄z軸，避免在拖曳過程中與其他物件碰撞
    void OnMouseDown()
    {
        if (colli != "None")
        {
            GameObject.Find(colli).GetComponent<Enemy>().CancelInvoke();
            CancelInvoke();
            colli = "None";
            isFight = false;
        }
        gameObject.transform.Translate(0, 0, 100);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    
    //讓英雄移動隨著鼠標移動
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        xPos = curPosition.x;
        yPos = curPosition.y;
        transform.position = curPosition;
    }

    //把z軸移動回原本的地方
    private void OnMouseUp()
    {
        Vector3 vector = new Vector3(xPos, yPos, zPos);
        transform.position = vector;
    }

    string colli = "None";
    bool isFight = false;

    //碰撞邏輯
    private void OnCollisionEnter(Collision collision)
    {
        //遇到敵人
        if (collision.gameObject.tag == "enemy")
        {
            //判斷是否已經進入戰鬥(避免英雄1打多)
            if (!gameObject.GetComponent<ControllableHero>().IsInvoking())
            {
                //存取敵人物件名字
                colli = collision.gameObject.name;
                //使用技能
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 1, skills[1].getCD());
            }
        }

        //遇到終點(測試用)
        else if (collision.gameObject.tag == "exit")
        {
            Destroy(gameObject);
            Debug.Log("hero reaches the goal");
        }
    }



    void useSkill1()
    {
        //判斷敵人是否死亡後，呼叫敵人的受傷函式
        if (GameObject.Find(colli) == null)
        {
            CancelInvoke();
            colli = "None";
            isFight = false;
            return;
        }
        Debug.Log("use skill 1!");
        ATK = skills[0].getAtk();
        GameObject.Find(colli).GetComponent<EnemyV2>().damage();

    }

    void useSkill2()
    {
        if (GameObject.Find(colli) == null)
        {
            CancelInvoke();
            colli = "None";
            isFight = false;
            return;
        }
        Debug.Log("use skill 2!");
        ATK = skills[1].getAtk();
        GameObject.Find(colli).GetComponent<EnemyV2>().damage();
    }


    //以下為給其他物件使用的函式
    public override float getHP() { return HP; }

    public override float getAtk() { return ATK; }

    public override float getCD() { return cd; }

    public override float getArmour() { return armour; }

    public override float getMSpd() { return moveSpeed; }
    
    //由敵人呼叫的函式，判斷自己受的傷害
    public override void damage()
    {
        HP -= GameObject.Find(colli).GetComponent<Enemy>().getAtk() - armour;
        Debug.Log("hero health: " + HP.ToString());
        if (HP <= 0)
        {
            Destroy(gameObject);
            CancelInvoke();
            GameObject.Find(colli).GetComponent<Enemy>().CancelInvoke();
        }
    }

    //由敵人呼叫的函式，判斷英雄是否可以與之戰鬥
    public override bool callFight()
    {
        if (!isFight) { isFight = true; return true; }
        return false;
    }

    //繼承的函式(用不到)
    public override int getDirX() { return 0; }

    public override int getDirY() { return 0; }

    public override void right() { return; }

    public override void left() { return; }

    public override void up() { return; }

    public override void down() { return; }

    public override void stop() { return; }
}
