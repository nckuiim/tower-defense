using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureHealthBar : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;
    private float passTime;
    private float lastTime;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
        lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;

        if(currentHealth/maxHealth != 1)
        {
            passTime = Time.time - lastTime;
            if(passTime >= 5 && currentHealth <= 100)
            {
                currentHealth += 10;
                if (currentHealth >= 100)
                    currentHealth = 100;
                lastTime = Time.time;
            }
        }
    }
}
