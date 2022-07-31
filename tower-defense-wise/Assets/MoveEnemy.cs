using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class MoveEnemy : MonoBehaviour
{
    private int x = 1;
    private int y = 0;

    [HideInInspector]
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // 1 
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        // 2 
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        // 3 
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                // 3.a 
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                // TODO: Rotate into move direction
            }
            else
            {
                // 3.b 
                Destroy(gameObject);

                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                // TODO: deduct health
                GameManagerBehavior gameManager =
                    GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;

            }
        }

        RotateIntoMoveDirection();
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

    string colli;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "rightTurn") { right(); }
        else if (collision.gameObject.tag == "leftTurn") { left(); }
        else if (collision.gameObject.tag == "upTurn") { up(); }
        else if (collision.gameObject.tag == "downTurn") { down(); }
        else if (collision.gameObject.tag == "enemy")
        {
            stop();
            colli = collision.gameObject.name;
            //InvokeRepeating("useSkill1", 1, skills[0].getCD());
            //InvokeRepeating("useSkill2", 2, skills[1].getCD());
        }
        else if (collision.gameObject.tag == "exit")
        {
            Destroy(gameObject);
            Debug.Log("hero reaches the goal");
        }
    }

    new void right() { x = 1; y = 0; }

    new void left() { x = -1; y = 0; }

    new void up() { x = 0; y = 1; }

    new void down() { x = 0; y = -1; }

    new void stop() { x = 0; y = 0; }
}
