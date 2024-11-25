using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        // listen for score update from score manager
        FindObjectOfType<ScoreManager>().OnScoreUpdate.AddListener(UpdateScoreValue);

        // listen for health update
        Health playerHealthObj = FindObjectOfType<Player>().HealthValue;
        playerHealthObj.OnHealthUpdate.AddListener(UpdateHealthValue);
        
        // update starting player health
        UpdateHealthValue(playerHealthObj.GetHealthValue());
        
    }

    public void UpdateScoreValue(int totalScore)
    {
        scoreText.text = totalScore.ToString();
    }

    public void UpdateHealthValue(float totalHealth)
    {
        healthText.text = totalHealth.ToString();
    }
}
