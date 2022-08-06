using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���O

//�^���P�ĤH���@�q�[�c
public abstract class FighterStruct : MonoBehaviour
{
    protected float maxHP;
    protected float HP;
    protected float oriAtk;
    protected float ATK;
    protected float cd;
    protected float armour;
    protected Skill[] skills;
    public int status;
    protected Animator myAnimator;
    protected SpriteRenderer mySpriteRenderer;

    protected string colli;

    //���}�԰����A
    protected void Reset()
    {
        CancelInvoke();
        colli = "None";
    }

    public float getHP() { return HP; }

    public float getAtk() { return ATK; }

    public float getCD() { return cd; }

    public float getArmour() { return armour; }



}
