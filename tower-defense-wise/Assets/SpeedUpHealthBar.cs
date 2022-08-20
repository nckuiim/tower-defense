using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpHealthBar : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;
    private float passTime;
    private float lastTime;
    public float newSpeed;
    public MoveEnemy Move;

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

        if (currentHealth / maxHealth != 1)
        {
            newSpeed = Move.speed;
            newSpeed = 10;
            /*passTime = Time.time - lastTime;
            if (passTime >= 5 && currentHealth <= 100)
            {
                currentHealth += 10;
                if (currentHealth >= 100)
                    currentHealth = 100;
                lastTime = Time.time;
            }*/
        }
    }

    public float howMuchHealth()
    {
        return currentHealth / maxHealth;
    }
}
