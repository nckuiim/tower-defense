using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public enum direction
    {
        right, left, up, down, stop
    }
    public abstract float getHP();

    public abstract void linkHealthBar(string name);

    public abstract void right();

    public abstract void left();

    public abstract void up();

    public abstract void down();

    public abstract void stop();
}
