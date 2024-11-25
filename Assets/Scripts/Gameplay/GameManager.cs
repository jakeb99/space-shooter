using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<Enemy> enemyList;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private List<Enemy> aliveEnemiesList;

    public ScoreManager scoreManager;

    // similar to unity event but from c# and add listener with += (faster then unity event)
    //public System.Action OnGameOver;

    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else 
            Destroy(Instance);

        aliveEnemiesList = new List<Enemy>();

        scoreManager = GetComponent<ScoreManager>();

        StartCoroutine(SpawnWaveOfEnemies());

        // get player object
        FindObjectOfType<Player>().HealthValue.OnDied.AddListener(GameOver);
    }

    private Enemy SpawnEnemy()
    {
        // get random spawn point from list of spawn points
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // get random enemy to spawn from list of enemy prefabs
        Enemy randomEnemy = enemyList[Random.Range(0, enemyList.Count)];
        Enemy enemyClone = Instantiate(randomEnemy, randomSpawnPoint.position, randomSpawnPoint.rotation);
        aliveEnemiesList.Add(enemyClone);
        return enemyClone;
    }

    // use coroutine to spawn wave of enemies
    private IEnumerator SpawnWaveOfEnemies()
    {
        while (true)
        {
            // do something here
            if (aliveEnemiesList.Count < 20)
            {
                // do something else after we wait
                Enemy clone = SpawnEnemy();
                
                // we have to wait for next frame so that enemy health is initialized
                //yield return new WaitForEndOfFrame();
                //clone.HealthValue.OnDied.AddListener(RemoveEnemyFromAliveList);
            }
            yield return new WaitForSeconds(Random.Range(1, 4));

        }
    }

    public void RemoveEnemyFromAliveList(Enemy enemyToRemove)
    {
        scoreManager.IncreaseScore(enemyToRemove.ScoreType);
        aliveEnemiesList.Remove(enemyToRemove);
    }

    private void GameOver()
    {
        OnGameOver.Invoke();

        StopAllCoroutines();
    }

    public void ResetGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}