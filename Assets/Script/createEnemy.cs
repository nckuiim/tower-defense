using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemy : MonoBehaviour
{
    public GameObject fighter;
    public GameObject healthBar;
    Vector3 vector = new Vector3(-12.68f, 1.71f, 0);
    Vector3 vector2 = new Vector3(-12.68f, 2.71f, 0);

    private void OnMouseDown()
    {
        GameObject b = Instantiate(healthBar, vector2, transform.rotation);
        GameObject a = Instantiate(fighter,vector,transform.rotation);
        b.GetComponent<healthBar>().setMaster(a);
    }
}
