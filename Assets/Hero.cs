using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : MonoBehaviour
{
    public enum atkType
    {
        physical, magic
    }
    public float XSpeed = 1f;
    public float YSpeed = 1f;
    public static float HP = 10;
    public static float ATK = 1;
    public static float AtkSpeed = 1;
    public static float armour = 0;

    protected int x = 1;
    protected int y = 0;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected void right() { }

    protected void left() { }

    protected void up() { }

    protected void down() { }

    protected void stop() { }

}
