using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : Skill
{
    private string Name = "skill1";
    private int atkType = 1;
    private float atk = 16;
    private float cd = 3;
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
