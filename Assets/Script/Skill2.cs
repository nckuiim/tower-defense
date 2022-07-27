using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : Skill
{
    private string Name = "skill2";
    private int atkType = 1;
    private float atk = 20;
    private float cd = 5;
    public override float getAtk()
    {
        return atk;
    }

    public override float getCD()
    {
        return cd;
    }

    public override string getName()
    {
        return Name;
    }

    public override int getAtkType()
    {
        return atkType;
    }

}
