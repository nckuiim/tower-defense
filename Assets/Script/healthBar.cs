using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;
    public GameObject master;
    // Use this for initialization
    void Start()
    {
        originalScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(master == null) { Destroy(gameObject); }
        else
        {
            currentHealth = master.GetComponent<Fighter>().getHP();
            Vector3 tmpScale = gameObject.transform.localScale;
            tmpScale.x = currentHealth / maxHealth * originalScale;
            gameObject.transform.localScale = tmpScale;

            Vector3 vector = master.transform.position;
            vector.y += 1;
            transform.position = vector;
        }

    }
    public void setMaster(GameObject a)
    {
        master = a;
        maxHealth = master.GetComponent<Fighter>().getHP();
        master.GetComponent<Fighter>().linkHealthBar(gameObject.name);
    }
}
