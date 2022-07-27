using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ĤH�ק�:�ƻs�^��(AutomaticHero)���欰�Ҧ��P�԰��޿�
public class EnemyV2 : Enemy
{
    private float moveSpeed = 1f;
    private float HP = 50;
    private float ATK = 12;
    private float cd = 5;
    private float armour = 0;

    private direction dir = direction.right;
    private direction preDir;
    private int horizon = 1;
    private int vertical = 0;
    Skill[] skills = new Skill[2];

    void Start()
    {
        //�w�˧ޯ�ϰ�
        skills[0] = new Skill1();
        skills[1] = new Skill2();
    }

    void Update()
    {
        if (dir == direction.left) { horizon = -1; vertical = 0; }
        else if (dir == direction.right) { horizon = 1; vertical = 0; }
        else if (dir == direction.up) { horizon = 0; vertical = 1; }
        else if (dir == direction.down) { horizon = 0; vertical = -1; }
        else if (dir == direction.stop) { horizon = 0; vertical = 0; }
        //�P�_�԰������P�_
        if (!gameObject.GetComponent<EnemyV2>().IsInvoking() && isStop()) { right(); }
        //����
        float moveX = horizon * moveSpeed * Time.deltaTime;
        float moveY = vertical * moveSpeed * Time.deltaTime;
        Vector2 ans = new Vector2(moveX, moveY);
        transform.Translate(ans);
    }

    bool isStop() { return (horizon == 0 && vertical == 0); }
    //�s���I��������
    string colli;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            colli = collision.gameObject.name;
            if (GameObject.Find(colli).GetComponent<Hero>().callFight())
            {
                stop();
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 2, skills[1].getCD());
            }
        }
        else if (collision.gameObject.tag == "exit")
        {
            Destroy(gameObject);
            Debug.Log("hero reaches the goal");
        }
    }

    void useSkill1()
    {
        //�P�_�ĤH�O�_���`��A�I�s�ĤH�����˨禡
        if (GameObject.Find(colli) == null)
        {
            CancelInvoke();
            return;
        }
        Debug.Log("use skill 1!");
        ATK = skills[0].getAtk();
        GameObject.Find(colli).GetComponent<Hero>().damage();
    }

    void useSkill2()
    {
        if (GameObject.Find(colli) == null)
        {
            CancelInvoke();
            return;
        }
        Debug.Log("use skill 2!");
        ATK = skills[1].getAtk();
        GameObject.Find(colli).GetComponent<Hero>().damage();
    }
    public override void damage()
    {
        HP -= GameObject.Find(colli).GetComponent<Hero>().getAtk() - armour;
        Debug.Log("hero health: " + HP.ToString());
        if (HP <= 0)
        {
            Destroy(gameObject);
            CancelInvoke();
            GameObject.Find(colli).GetComponent<Hero>().CancelInvoke();
        }
    }
    public override void right() { dir = direction.right; }

    public override void left() { dir = direction.left; }

    public override void up() { dir = direction.up; }

    public override void down() { dir = direction.down; }

    public override void stop() { preDir = dir; dir = direction.stop; }

    public override float getHP() { return HP; }

    public override float getAtk() { return ATK; }

    public override float getCD() { return cd; }

    public override float getArmour() { return armour; }

    public override int getDirX() { return horizon; }
    
    public override int getDirY() { return vertical; }
    
    public override float getMSpd() { return moveSpeed; }

}
