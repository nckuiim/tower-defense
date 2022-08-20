using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] waypoints;
    //public GameObject testEnemyPrefab;
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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        // 1
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)//先確認當前的wave是否為最後一波，若不是則進入迴圈
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;//現在時間距離上次生成敵人過了多久
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)//若是wave生成的第一隻敵人，確認timeInterval大於timeBetweemWaves。
            {                                                  //不是第一隻則要確定其timeInterval大於spawnInterval。最後確認是否以生產夠多隻。
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)//若敵人生產數量達上限，且螢幕上無敵人，生產下一波wave。
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
            gameManager.gameOver = true;//以生產完所有wave，遊戲結束。
            //GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }

    }

    [System.Serializable]//在Inspector中可修改數值
    public class Wave
    {
        public GameObject enemyPrefab;//此波wave中採用哪個prefab
        public float spawnInterval = 2;//每隻敵人出生的間隔時間
        public int maxEnemies = 20;//這波wave中敵人的數量
    }

}
