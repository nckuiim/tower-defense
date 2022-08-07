using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�l�M
//���:���^���]�i�H�ϥγo�Ӳ����޿�B�ѨM�ĤH�P�^����Ե�����|������U�@��waypoint��bug

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
    public float maxSpeed;
    public float speed = 1.0f;
    bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }
    float startfight = 0;
    float endfight = 0;
    string colli;
    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            // 1 
            Vector3 startPosition = waypoints[currentWaypoint].transform.position;
            Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
            // 2 
            float pathLength = Vector3.Distance(startPosition, endPosition);
            float totalTimeForPath = pathLength / speed;
            float currentTimeOnPath = Time.time - lastWaypointSwitchTime - (endfight - startfight);
            gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
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
        else
        {
            if (GameObject.Find(colli) == null)
            {
                endfight += Time.time;
                move = true;
            }
        }
    }

    bool isDestroyed;
    bool isFight;

    private void OnCollisionExit(Collision collision)
    {

        //colli = "None";
        if (collision.gameObject.tag == "Hero")
        {
            Debug.Log("hit");

            if (isFight)
            {
                endfight += Time.time;
                move = true;
            }
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hero" && tag == "Enemy")
        {
            colli = collision.gameObject.name;
            isFight = collision.gameObject.GetComponent<HeroFight>().callFight();
            if (isFight)
            {
                startfight += Time.time;
                move = false;
            }

        }
        else if(collision.gameObject.tag == "Enemy" && tag == "Hero")
        {
            if(move == true)
            {
                colli = collision.gameObject.name;
                startfight += Time.time;
                move = false;
            }
        }
    }

}
