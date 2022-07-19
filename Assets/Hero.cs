using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public abstract float getMoveSpd();
    public abstract float getHP();
    public abstract float getAtk();
    public abstract float getCD();
    public abstract float getArmour();

    protected void damage() { }

    protected void right() { }

    protected void left() { }

    protected void up() { }

    protected void down() { }

    protected void stop() { }

}
