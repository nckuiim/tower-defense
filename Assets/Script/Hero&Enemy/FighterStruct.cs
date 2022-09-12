using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//詠吏

//英雄與敵人的共通架構
public abstract class FighterStruct : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI HPTextS;
    public string title;
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

    protected string colli = "None";

    //離開戰鬥狀態
    protected void Reset()
    {
        CancelInvoke();
        colli = "None";
    }

    public void HPChangeS()
    {
        HPTextS.text = HP.ToString();
    }

    public float getHP() { return HP; }

    public float getAtk() { return ATK; }

    public float getCD() { return cd; }

    public float getArmour() { return armour; }



}
