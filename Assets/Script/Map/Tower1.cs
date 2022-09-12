using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower1 : Tower
{
    public void Start()
    {
        range = 4.0f;
        fireRate = 1.0f;
        num = 0;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        canAttack = false; //一開始的物件(塔的模板)不可攻擊
    }

}
