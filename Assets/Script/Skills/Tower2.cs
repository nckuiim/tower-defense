using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : Tower
{
    // Start is called before the first frame update
    void Start()
    {
        range = 2f;//�g�{
        fireRate = 1f;//�C��]�@�o
        num = 2;
        canAttack = false;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
}
