using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform[] spawnPointsArray;
    [SerializeField] private List<Enemy> listOfAllEnemiesAlive;
    
    private ScoreManager scoreManager;

    //public System.Action OnGameOver; //lighter than an Event to use for execution

    public UnityEvent OnGameStart;
    public UnityEvent OnGameOver;


    void Start()
    {
        //OnGameOver += 
        if (instance == null)  
            instance = this;
        else  
            Destroy(gameObject);

        //InvokeRepeating("SpawnEnemy", 3f, 2f);
        listOfAllEnemiesAlive = new List<Enemy>();
        
        scoreManager = GetComponent<ScoreManager>();

        FindObjectOfType<Player>().healthValue.OnDeath.AddListener(GamOver);

        StartCoroutine(SpawnWaveOfEnemies());
        SpawnEnemy();
    }

    private void GamOver()
    {
        OnGameOver.Invoke();
        StopAllCoroutines();
    }

    private Enemy SpawnEnemy()
    {
        int randomIndex = Random.Range(0, spawnPointsArray.Length); 
        Transform randomSpawnPoint = spawnPointsArray[randomIndex];
        Enemy enemyClone = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);
        listOfAllEnemiesAlive.Add(enemyClone);  
        
        return enemyClone;
        //enemyClone.healthValue.OnDeath.AddListener(RemoveEnemyFromList);    
    }

    public void RemoveEnemyFromList(Enemy enemyToBeRemoved)
    {
        scoreManager.IncreaseScore(ScoreType.EnemyKilled);

        listOfAllEnemiesAlive.Remove(enemyToBeRemoved); // better solution
        
        
        /*
        for (int index = 0; index < listOfAllEnemiesAlive.Count; index++) 
        {
            if (listOfAllEnemiesAlive[index] == null)
            {
                listOfAllEnemiesAlive.RemoveAt(index);
            }
        }
        */
    }

    private IEnumerator SpawnWaveOfEnemies()
    {
        //do something here
        while (true) //while enemies are than 20
        {
            if(listOfAllEnemiesAlive.Count < 5)
            {
               Enemy clone = SpawnEnemy();
               //yield return new WaitForEndOfFrame();//waiting for health to be initialized
               //clone.healthValue.OnDeath.AddListener(RemoveEnemyFromList);
            }
            yield return new WaitForSeconds(Random.Range(1, 4));
        }
        //do something here after a random sec delay 
    }

}
