using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//泓霖
//改動:可以讀取英雄及時血量

public class HealthBar : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    private float originalScale;
    public GameObject master;
    // Use this for initialization
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
        maxHealth = master.GetComponent<FighterStruct>().getHP();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = master.GetComponent<FighterStruct>().getHP();
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
