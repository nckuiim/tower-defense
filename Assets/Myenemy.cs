using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    public float x_speed;
    public float y_speed;
    public string enemy_type = "type1";
    public float HP = 50f;

    [HideInInspector]
    public float x_startSpeed = 1f;
    [HideInInspector]
    public float y_startSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        x_speed = x_startSpeed;
        y_speed = y_startSpeed;

        InvokeRepeating("ToCallSpeedRecover", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x_speed*Time.deltaTime, y_speed*Time.deltaTime, 0);
        
    }

    public string Return_type()
    {
        return enemy_type;
    }

    public void SpeedRecover()
    {
        x_speed=x_startSpeed;
        y_speed=y_startSpeed;
    }

    public void ToCallSpeedRecover()
    {
        if(x_speed<x_startSpeed && y_speed < y_startSpeed)
        {
            Invoke("SpeedRecover", 1f);
        }
    }

    
}
