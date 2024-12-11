using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData 
{
    public string username;
    public int highestScore;

    public ScoreData(string usernameParam, int highestScoreParam)
    {
        username = usernameParam;
        highestScore = highestScoreParam;
    }
}
