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
    [HideInInspector]//不讓編輯的人可以在Inspector中修改
    public GameObject[] waypoints;
    private int currentWaypoint = 0;//紀錄當前敵人正在離開的waypoint
    private float lastWaypointSwitchTime;//儲存敵人經過的時間
    public float speed = 1.0f;
    public float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
      
        // 1 
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;
        // 2 
        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / currentSpeed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        //Lerp算出從startPosition到endPosition之間currentTimeOnPath/totalTimeForPath此數值的距離(當前敵人應在位置)，需要在update中不停呼叫以更新位置
        gameObject.transform.position = Vector2.Lerp(startPosition, endPosition, currentTimeOnPath / totalTimeForPath);
        // 3 
        //檢查敵人是否已抵達了endPosition，若抵達有兩種情況。1.還沒到終點，切換到下一個currentWaypoint，更新lastWaypointSwitchTime。2.若以抵達終點，破壞它。
        if (gameObject.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length - 2)
            {
                // 3.a 
                currentWaypoint++;
                lastWaypointSwitchTime = Time.time;
                // TODO: Rotate into move direction
                RotateIntoMoveDirection();
            }
            else
            {
                // 3.b 
                Destroy(gameObject);

                // TODO: deduct health
                GameManagerBehavior gameManager =
                    GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
                gameManager.Health -= 1;

            }
        }

        changeSpeed();
    }

    private void changeSpeed()
    {
        float leftHealth = GameObject.Find("Enemy").GetComponent<SpeedUpHealthBar>().howMuchHealth();
        print(leftHealth);
        if (leftHealth <= 0.5)
        {
            print(leftHealth);
            currentSpeed = 10;
        }
    }
    private void RotateIntoMoveDirection()
    {
        //1
        Vector3 newStartPosition = waypoints[currentWaypoint].transform.position;
        Vector3 newEndPosition = waypoints[currentWaypoint + 1].transform.position;
        Vector3 newDirection = (newEndPosition - newStartPosition);
        //2
        //以Mathf.Atan2來確認newDirection指向的角度
        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * 180 / Mathf.PI;
        //3
        //轉動名為Sprite的子物件，不會轉動到血條
        GameObject sprite = gameObject.transform.Find("Sprite").gameObject;
        sprite.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

}
