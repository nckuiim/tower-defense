using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        range = 2f;//射程
        fireRate = 1f;//每秒設一發
        num = 2;
        canAttack = false;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
}
