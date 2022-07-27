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

    // �w�˧ޯ�
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

    //���ʭ^��z�b�A�קK�b�즲�L�{���P��L����I��
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
    
    //���^�������H�۹��в���
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        xPos = curPosition.x;
        yPos = curPosition.y;
        transform.position = curPosition;
    }

    //��z�b���ʦ^�쥻���a��
    private void OnMouseUp()
    {
        Vector3 vector = new Vector3(xPos, yPos, zPos);
        transform.position = vector;
    }

    string colli = "None";
    bool isFight = false;

    //�I���޿�
    private void OnCollisionEnter(Collision collision)
    {
        //�J��ĤH
        if (collision.gameObject.tag == "enemy")
        {
            //�P�_�O�_�w�g�i�J�԰�(�קK�^��1���h)
            if (!gameObject.GetComponent<ControllableHero>().IsInvoking())
            {
                //�s���ĤH����W�r
                colli = collision.gameObject.name;
                //�ϥΧޯ�
                InvokeRepeating("useSkill1", 1, skills[0].getCD());
                InvokeRepeating("useSkill2", 1, skills[1].getCD());
            }
        }

        //�J����I(���ե�)
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


    //�H�U������L����ϥΪ��禡
    public override float getHP() { return HP; }

    public override float getAtk() { return ATK; }

    public override float getCD() { return cd; }

    public override float getArmour() { return armour; }

    public override float getMSpd() { return moveSpeed; }
    
    //�ѼĤH�I�s���禡�A�P�_�ۤv�����ˮ`
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

    //�ѼĤH�I�s���禡�A�P�_�^���O�_�i�H�P���԰�
    public override bool callFight()
    {
        if (!isFight) { isFight = true; return true; }
        return false;
    }

    //�~�Ӫ��禡(�Τ���)
    public override int getDirX() { return 0; }

    public override int getDirY() { return 0; }

    public override void right() { return; }

    public override void left() { return; }

    public override void up() { return; }

    public override void down() { return; }

    public override void stop() { return; }
}
