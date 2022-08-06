using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//µú¦O

public class createEnemy : MonoBehaviour
{
    public GameObject fighter;
    public float posX;
    public float posY;
    private Vector3 fighterPos;

    private void Start()
    {
        fighterPos = new Vector3(posX, posY, 0);
    }


    private void OnMouseDown()
    {
        GameObject a = Instantiate(fighter,fighterPos,transform.rotation);
    }
}
