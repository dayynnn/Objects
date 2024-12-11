using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        FindObjectOfType<ScoreManager>().OnScoreChanged.AddListener(UpdateScoreaValue);
        
        Player playerObject = FindObjectOfType<Player>();

        playerObject.healthValue.OnHealthChanged.AddListener(UpdatePlayerHealthValue);
        UpdatePlayerHealthValue(playerObject.healthValue.GetHealthValue());
    }

    public void UpdateScoreaValue(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdatePlayerHealthValue(float health)
    {
        healthText.text = health.ToString();
        //healthText.text = health.ToString("F2"); //specifying 2 dec place with F2
    }
}
