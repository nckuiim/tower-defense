using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Fighter
{
    private string healthBarName;
    
    public abstract float getAtk();
    public abstract float getCD();
    public abstract float getArmour();
    public abstract void damage();
    public abstract int getDirX();
    public abstract int getDirY();
    public abstract float getMSpd();
    public abstract bool callFight();
    public override void linkHealthBar(string name) { healthBarName = name; }
}
