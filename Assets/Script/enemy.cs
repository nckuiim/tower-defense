/*using System.Collections;
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

    
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class enemy : MonoBehaviour
{

    public float x_speed;
    public float y_speed;
    public string enemy_type = "type1";
    public float HP = 100f;
    public float delay_time;
    bool delay = true;

    [HideInInspector]
    public float x_startSpeed = 1f;
    [HideInInspector]
    public float y_startSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        x_speed = x_startSpeed;
        y_speed = y_startSpeed;

        InvokeRepeating("ToCallSpeedRecover", 0f, 3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (delay)
        {
            Invoke("moveToStart", delay_time);
            delay = false;
        }
        if (transform.position.x >= 6 && transform.position.x < 1000)
        {
            //gameObject.GetComponent<Renderer>().enabled = false;//
            transform.Translate(-x_speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x >= 2 && transform.position.x < 6)
        {
            //gameObject.GetComponent<Renderer>().enabled = true;//
            transform.Translate(-x_speed * Time.deltaTime, 0, 0);
        }
        else if (transform.position.x >= 0 && transform.position.y >= -2)
            transform.Translate(0, -y_speed * Time.deltaTime, 0);
        else if (transform.position.y < -2 && transform.position.x >= -2)
            transform.Translate(-x_speed * Time.deltaTime, 0, 0);
        else if (transform.position.x < -2 && transform.position.y <= 2)
            transform.Translate(0, y_speed * Time.deltaTime, 0);
        else if (transform.position.x < -2 && transform.position.x > -6 && transform.position.y > 2)
            transform.Translate(-x_speed * Time.deltaTime, 0, 0);
        else if (transform.position.x <= -6)
        {
            transform.position = new Vector2(2000, 2000);
            RemainEnemy.en -= 1;
        }


    }

    public string Return_type()
    {
        return enemy_type;
    }

    public void SpeedRecover()
    {
        x_speed = x_startSpeed;
        y_speed = y_startSpeed;
    }

    public void ToCallSpeedRecover()
    {
        if (x_speed < x_startSpeed && y_speed < y_startSpeed)
        {
            Invoke("SpeedRecover", 1f);
        }
    }

    public void moveToStart()
    {
        transform.position = new Vector2(6, 2);
    }

}