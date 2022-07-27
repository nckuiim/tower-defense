using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Fighter
{
    private string healthBarName;

    public abstract void damage();

    public abstract float getAtk();

    public abstract float getCD();

    public abstract float getArmour();

    public abstract int getDirX();

    public abstract int getDirY();

    public abstract float getMSpd();

    public override void linkHealthBar(string name) { healthBarName = name; }
}
