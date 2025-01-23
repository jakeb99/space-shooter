using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void Start()
    {
        // listen for score update from score manager
        FindObjectOfType<ScoreManager>().OnScoreUpdate.AddListener(UpdateScoreValue);

        // listen for health update
        Health playerHealthObj = FindObjectOfType<Player>().HealthValue;
        playerHealthObj.OnHealthUpdate.AddListener(UpdateHealthValue);
        
        // update starting player health
        UpdateHealthValue(playerHealthObj.GetHealthValue());

        GameManager.Instance.OnGameOver.AddListener(UpdateHighScoreValue);
        
    }

    public void UpdateScoreValue(int totalScore)
    {
        scoreText.text = totalScore.ToString();
    }

    public void UpdateHealthValue(float totalHealth)
    {
        healthText.text = totalHealth.ToString();
    }

    public void UpdateHighScoreValue()
    {
        var highScore = FindObjectOfType<ScoreManager>().highestScore;
        highScoreText.text =  "Highscore:  " + highScore.ToString();
    }
}
