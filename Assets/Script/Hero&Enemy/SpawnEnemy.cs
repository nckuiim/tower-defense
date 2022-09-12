using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�l�M

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints1;
    public GameObject[] waypoints2;
    public GameObject[] waypoints3;
    public GameObject[] waypoints4;
    public GameObject testEnemyPrefab;
    public Wave[] waves;
    public int timeBetweenWaves = 5;

    private GameManagerBehavior gameManager;

    private float lastSpawnTime;
    private int enemiesSpawned = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;
        lastSpawnTime = Time.time;
        gameManager = gameObject.GetComponent<GameManagerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);

                System.Random rnd = new System.Random();
                int wayNum = rnd.Next(1, 5);
                switch (wayNum)
                {
                    case 1:
                        newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints1;
                        break;
                    case 2:
                        newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints2;
                        break;
                    case 3:
                        newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints3;
                        break;
                    case 4:
                        newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints4;
                        break;
                    default:
                        Debug.Log("error");
                        break;
                }
                newEnemy.name = newEnemy.name + enemiesSpawned;
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++;
                //gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
        else
        {
            gameManager.gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }

    }

}
