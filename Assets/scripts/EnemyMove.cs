using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject[] waypoints; //紀錄移動路徑上點的array
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
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                // TODO: Rotate into move direction
            }
            else
            {
                // 3.b 
                Destroy(gameObject);
                // TODO: deduct health
            }
        }
        /*
        int[] path1 = {0,1,2,3,4,5,6,7,8,9,10,11,12,13 };
        int[] path2 = {0,1,2,3,4,5,23,24,11,12,13 };
        int[] path3 = {0,1,2,3,4,5,23,24,25,22,26 };
        int[] path4 = {0,1,2,3,4,5,6,7,8,9,10,11,24,25,22,26 };
        int[] path5 = {0,1,14,15,16,17,18,19,20,21,22,26};
        int indexofpath = 0;
        */
        /* path select
        Random rd = new Random();
        int randomnumber = rd.Next(1, 5);

        switch (randomnumber)
        {
            case 1:
                indexofpath = 0;
                startPosition = waypoints[indexofpath].transform.position;
                endPosition = waypoints[indexofpath+1].transform.position;
                if (gameObject.transform.position.Equals(endPosition))
                {
                    if (currentWaypoint < path1.Length - 2)
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
                        // TODO: deduct health
                    }
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;

        }
        */





    }
}
