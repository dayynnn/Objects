using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public UnityEvent<int> OnScoreChanged;
    [SerializeField] private int totalScore;
    [SerializeField] private int highestScore;

    [Header("Score Manager")]
    [SerializeField] private int scorePerEnemy;
    [SerializeField] private int scorePerCoin;
    [SerializeField] private int scorePerPowerUp;

    [SerializeField] private List<ScoreData> allScores = new List<ScoreData>();
    
    [SerializeField] private ScoreData latestScore;
    
    private void Start()
    {
        Player playerObject = FindObjectOfType<Player>();
        playerObject.healthValue.OnDeath.AddListener(RegisterScore);

        highestScore = PlayerPrefs.GetInt("HighScore");
        
        //At start of the game
        //I'll retrieve the string from player prefs
        string latestScoreInJson = PlayerPrefs.GetString("LatestScore");

        //And try to convert it back into a ScoreData object/class
        latestScore = JsonUtility.FromJson<ScoreData>(latestScoreInJson);

    }

    private void RegisterScore() //when the player dies
    {
        //Create an object filled with information    
        latestScore = new ScoreData("MDD", totalScore);
        
        //Convert object(class) into a string in json format
        string latestScoreInJson = JsonUtility.ToJson(latestScore);

        //Save that string into PlayerPrefs
        PlayerPrefs.SetString("LatestScore", latestScoreInJson);
        

        if(totalScore > highestScore)
        {
            //we got a new highscore
            highestScore = totalScore;

            PlayerPrefs.SetInt("HighScore", highestScore);
        }
    }

    public void IncreaseScore(ScoreType action)
    {

        switch (action) //use switch instead of a lot of if else statements. Cleaner code
        {
            case ScoreType.EnemyKilled:
                //code here
                totalScore += scorePerEnemy;
                break;

            case ScoreType.CoinCollected:
                //code here
                totalScore += scorePerCoin;
                break;

            case ScoreType.PowerUpCollected:
                //code here
                totalScore += scorePerPowerUp;
                break;

        }        

        OnScoreChanged.Invoke(totalScore);
    }

    public void EnemyKilled()
    {

    }

    public void CoinCollected()
    {

    }


}
