using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : Skill
{
    string Name = "skill1";
    int atkType = 1;
    private new float atk = 16;
    float cd = 3;
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
