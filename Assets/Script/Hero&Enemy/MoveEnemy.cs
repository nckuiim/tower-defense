using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//泓霖
//改動:讓英雄也可以使用這個移動邏輯、解決敵人與英雄對戰結束後會順移到下一個waypoint的bug

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class MoveEnemy : MonoBehaviour
{

    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float maxSpeed = 1.0f;
    public float speed = 1.0f;
    private bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[currentWaypoint].transform.position;
        lastWaypointSwitchTime = Time.time;
        InvokeRepeating("ToCallSpeedRecover", 0f, 1f);
    }
    float startfight = 0;
    float endfight = 0;
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            // 1 
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
            // 2 
            float pathLength = Vector3.Distance(startPosition, endPosition);
            float totalTimeForPath = pathLength / speed;
            //float currentTimeOnPath = Time.time - lastWaypointSwitchTime - (endfight - startfight);
            gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, Time.deltaTime / totalTimeForPath);
            // 3 
            if (gameObject.transform.position.Equals(endPosition))
            {
                if (currentWaypoint < waypoints.Length - 2)
                {
                    // 3.a 
                    currentWaypoint++;
                    lastWaypointSwitchTime = Time.time;
                    startfight = 0;
                    endfight = 0;
                    // TODO: Rotate into move direction
                }
                else
                {
                    // 3.b 
                    Destroy(gameObject);
                    RemainEnemy.en--;
                    //AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                    //AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                    // TODO: deduct health
                    GameManagerBehavior gameManager =
                        GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                    gameManager.Health -= 1;

                }
            }

            RotateIntoMoveDirection();
        }
    }



    private void RotateIntoMoveDirection()
    {
        //1
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        //2
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        //3
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    public void stopFighter()
    {
        move = false;
        startfight += Time.time;
    }

    public void moveFighter()
    {
        move = true;
        endfight += Time.time;
    }

    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            waypoints[currentWaypoint + 1].transform.position);
        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance += Vector2.Distance(startPosition, endPosition);
        }
        return distance;
    }

    public void SpeedRecover()
    {
        speed = maxSpeed;
    }

    public void ToCallSpeedRecover()
    {
        if (speed < maxSpeed)
        {
            Invoke("SpeedRecover", 1f);
        }
    }
}
